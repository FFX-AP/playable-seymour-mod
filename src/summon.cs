// SPDX-License-Identifier: MIT

namespace Fahrenheit.Mods.Seymour;

public unsafe partial class SeymourModule : FhModule {
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MsParseCommand(byte* param_1);
    private static FhMethodHandle<MsParseCommand> _MsParseCommand
        => new ( new FhMethodLocation("FFX.exe", 0x3AE380) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOBtlCtrlHelpWin();
    private static FhMethodHandle<TOBtlCtrlHelpWin> _TOBtlCtrlHelpWin
        => new ( new FhMethodLocation("FFX.exe", 0x491250) );
    private byte* p_toBwNum => FhUtil.ptr_at<byte>(0x01fcc092);


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ushort* TOGetSaveWindow(int chr_id, BtlWindowType window_type, int* out_length);
    private static FhMethodHandle<TOGetSaveWindow> _TOGetSaveWindow
        => new ( new FhMethodLocation("FFX.exe", 0x49B510) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint TkMenuSummonEnableMask();
    private static FhMethodHandle<TkMenuSummonEnableMask> _TkMenuSummonEnableMask
        => new ( new FhMethodLocation("FFX.exe", 0x4AB190) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MsSetSaveParam(uint chr_id);
    private static FhMethodHandle<MsSetSaveParam> _MsSetSaveParam
        => new ( new FhMethodLocation("FFX.exe", 0x3861B0) );
    private static uint aeon = 0;


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SphereGridPlyParam* MsGetChrAbilityMap(int chr_id, SaveParam* save_param);
    private static FhMethodHandle<MsGetChrAbilityMap> _MsGetChrAbilityMap
        => new ( new FhMethodLocation("FFX.exe", 0x385C20) );
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x3C)]
    public struct SaveParam {
        [FieldOffset(0x00)] public uint strength;
        [FieldOffset(0x04)] public uint defense;
        [FieldOffset(0x08)] public uint magic;
        [FieldOffset(0x0C)] public uint magic_defense;
        [FieldOffset(0x10)] public uint agility;
        [FieldOffset(0x14)] public uint luck;
        [FieldOffset(0x18)] public uint evasion;
        [FieldOffset(0x1C)] public uint accuracy;
        [FieldOffset(0x20)] public uint hp;
        [FieldOffset(0x24)] public uint mp;
    }



    // Extra24 command -> Summon
    int h_MsParseCommand(byte* param_1) {
        uint uVar13 = param_1[2];
        int iVar14 = (int)uVar13 * 0x10;
        ushort* com_id = (ushort*)(param_1 + iVar14 + 8);

        if (*com_id == 0x3130) {
            *com_id = 0x3117;
            int result = _MsParseCommand.chain_from(h_MsParseCommand).fnptr!(param_1);
            *com_id = 0x3130;
            return result;
        }
        return _MsParseCommand.chain_from(h_MsParseCommand).fnptr!(param_1);
    }

    // Extra24 Summon Help text
    void h_TOBtlCtrlHelpWin() {
        int window_id = *p_toBwNum;
        BtlWindow* currentwindow = &Globals.Battle.windows[window_id];

        if (currentwindow->window_command_id == 0x3130) {
            currentwindow->window_command_id = 0x3117;
            _TOBtlCtrlHelpWin.chain_from(h_TOBtlCtrlHelpWin).fnptr!();
            currentwindow->window_command_id = 0x3130;
            return;
        }
        _TOBtlCtrlHelpWin.chain_from(h_TOBtlCtrlHelpWin).fnptr!();
    }

    // Battle Summon List
    ushort* h_TOGetSaveWindow(int chr_id, BtlWindowType window_type, int* out_length) {
        if ((uint)window_type == 5) {
            ushort* originallist = _TOGetSaveWindow.chain_from(h_TOGetSaveWindow).fnptr!(chr_id, window_type, out_length);
            Span<ushort> listSpan = new(originallist, *out_length);
            if (chr_id == 1) {
                if (!Globals.save_data->has_anima && listSpan.Contains<ushort>(PlySaveId.PC_ANIMA)) {
                    int new_length = 0;
                    for (int i = 0; i < *out_length; i++) {
                        if (listSpan[i] != PlySaveId.PC_ANIMA) {
                            listSpan[new_length] = listSpan[i];
                            new_length++;
                        }
                    }
                    for (int i = new_length; i < *out_length; i++) {
                        listSpan[i] = 0xFFFF;
                    }
                    *out_length = new_length;
                }
                return originallist;
            }
            if (chr_id == 7) {
                if (listSpan.Contains<ushort>(PlySaveId.PC_ANIMA)) {
                    listSpan.Fill(0xFFFF);
                    listSpan[0] = PlySaveId.PC_ANIMA;
                    *out_length = 1;
                    return originallist;
                }
                else {
                    listSpan.Fill(0xFFFF);
                    *out_length = 0;
                    return originallist;
                }
            }
            else {
                return originallist;
            }
        }
        return _TOGetSaveWindow.chain_from(h_TOGetSaveWindow).fnptr!(chr_id, window_type, out_length);
    }

    // Overdrive Mode Menu
    uint h_TkMenuSummonEnableMask() {
        if (FhXCall.TkMenuGetCurrentPlayer.fnptr!() == 1) {
            if (!Globals.save_data->has_anima) {
                return _TkMenuSummonEnableMask.chain_from(h_TkMenuSummonEnableMask).fnptr!() & ~(1u << 0x0D); // Only display Anima in Yuna's menu once unlocked
            }
        }
        return _TkMenuSummonEnableMask.chain_from(h_TkMenuSummonEnableMask).fnptr!();
    }

    // Make Anima's stats scale with Seymour's
    void h_MsSetSaveParam(uint chr_id) {
        aeon = chr_id;
        _MsSetSaveParam.chain_from(h_MsSetSaveParam).fnptr!(chr_id);
        aeon = 0;
    }

    SphereGridPlyParam* h_MsGetChrAbilityMap(int chr_id, SaveParam* save_param) {
        SphereGridPlyParam* param;

        if (chr_id == 1 && aeon == 0x0D) {
            chr_id = 7; // Scale with Seymour
        }
        param = _FUN_00798800.fnptr!(chr_id);
        save_param->hp = Globals.save_data->ply_saves[chr_id].base_hp;
        save_param->mp = Globals.save_data->ply_saves[chr_id].base_mp;
        if (chr_id == 7 && aeon == 0x0D) {
            save_param->strength = 0;
            save_param->defense  = 0;
            // Removed Strength & Defense scalings - Anima was too overpowered with them
            // when using Seymour's stats as a base.
        }
        else {
            save_param->strength  = Globals.save_data->ply_saves[chr_id].base_strength;
            save_param->defense   = Globals.save_data->ply_saves[chr_id].base_defense;
        }
        save_param->magic         = Globals.save_data->ply_saves[chr_id].base_magic;
        save_param->magic_defense = Globals.save_data->ply_saves[chr_id].base_magic_defense;
        save_param->agility       = Globals.save_data->ply_saves[chr_id].base_agility;
        save_param->luck          = Globals.save_data->ply_saves[chr_id].base_luck;
        save_param->evasion       = Globals.save_data->ply_saves[chr_id].base_evasion;
        save_param->accuracy      = Globals.save_data->ply_saves[chr_id].base_accuracy;
        if (param != (SphereGridPlyParam*)0x0) {
            save_param->hp            = save_param->hp            + param->hp * 50;
            save_param->mp            = save_param->mp            + param->mp * 5;
            save_param->strength      = save_param->strength      + param->strength;
            save_param->defense       = save_param->defense       + param->defense;
            save_param->magic         = save_param->magic         + param->magic;
            save_param->magic_defense = save_param->magic_defense + param->magic_defense;
            save_param->agility       = save_param->agility       + param->agility;
            save_param->luck          = save_param->luck          + param->luck;
            save_param->evasion       = save_param->evasion       + param->evasion;
            save_param->accuracy      = save_param->accuracy      + param->accuracy;
        }
        return param;
    }
}