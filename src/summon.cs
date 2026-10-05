// SPDX-License-Identifier: MIT

namespace Fahrenheit.Mods.Seymour;

public unsafe partial class SeymourModule : FhModule {
    private byte* p_toBwNum => FhUtil.ptr_at<byte>(0x01fcc092);

    private uint aeon = 0;



    // Extra24 command -> Summon
    int h_MsParseCommand(byte* param_1) {
        uint uVar13 = param_1[2];
        int iVar14 = (int)uVar13 * 0x10;
        ushort* com_id = (ushort*)(param_1 + iVar14 + 8);

        if (*com_id == 0x3130) {
            *com_id = 0x3117;
            int result = FhXCall.MsParseCommand.chain_from(h_MsParseCommand).fnptr!(param_1);
            *com_id = 0x3130;
            return result;
        }
        return FhXCall.MsParseCommand.chain_from(h_MsParseCommand).fnptr!(param_1);
    }

    // Extra24 Summon Help text
    void h_TOBtlCtrlHelpWin() {
        int window_id = *p_toBwNum;
        BtlWindow* currentwindow = &Globals.Battle.windows[window_id];

        if (currentwindow->window_command_id == 0x3130) {
            currentwindow->window_command_id = 0x3117;
            FhXCall.TOBtlCtrlHelpWin.chain_from(h_TOBtlCtrlHelpWin).fnptr!();
            currentwindow->window_command_id = 0x3130;
            return;
        }
        FhXCall.TOBtlCtrlHelpWin.chain_from(h_TOBtlCtrlHelpWin).fnptr!();
    }

    // Battle Summon List
    ushort* h_TOGetSaveWindow(int chr_id, BtlWindowType window_type, int* out_length) {
        if ((uint)window_type == 5) {
            ushort* originallist = FhXCall.TOGetSaveWindow.chain_from(h_TOGetSaveWindow).fnptr!(chr_id, window_type, out_length);
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
        return FhXCall.TOGetSaveWindow.chain_from(h_TOGetSaveWindow).fnptr!(chr_id, window_type, out_length);
    }

    // Overdrive Mode Menu
    uint h_TkMenuSummonEnableMask() {
        if (FhXCall.TkMenuGetCurrentPlayer.fnptr!() == 1) {
            if (!Globals.save_data->has_anima) {
                return FhXCall.TkMenuSummonEnableMask.chain_from(h_TkMenuSummonEnableMask).fnptr!() & ~(1u << 0x0D); // Only display Anima in Yuna's menu once unlocked
            }
        }
        return FhXCall.TkMenuSummonEnableMask.chain_from(h_TkMenuSummonEnableMask).fnptr!();
    }

    // Make Anima's stats scale with Seymour's
    void h_MsSetSaveParam(uint chr_id) {
        aeon = chr_id;
        FhXCall.MsSetSaveParam.chain_from(h_MsSetSaveParam).fnptr!(chr_id);
        aeon = 0;
    }

    SphereGridPlyParam* h_MsGetChrAbilityMap(int chr_id, SaveParam* save_param) {
        SphereGridPlyParam* param;

        if (chr_id == 1 && aeon == 0x0D) {
            chr_id = 7; // Scale with Seymour
        }
        param = FUN_00798800.fnptr!(chr_id);
        save_param->hp            = Globals.save_data->ply_saves[chr_id].base_hp;
        save_param->mp            = Globals.save_data->ply_saves[chr_id].base_mp;
        save_param->strength      = Globals.save_data->ply_saves[chr_id].base_strength;
        save_param->defense       = Globals.save_data->ply_saves[chr_id].base_defense;
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