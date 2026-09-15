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

    void* h_MsGetChrAbilityMap(int chr_id, void* save_param) {
        SphereGridPlyParam* pMVar1;

        uint* save_param_00 = (uint*)save_param;
        if (chr_id == 1 && aeon == 0x0D) {
            chr_id = 7; // Scale with Seymour
        }
        pMVar1 = FUN_003987f0.fnptr!(chr_id);
        save_param_00[8] = Globals.save_data->ply_saves[chr_id].base_hp;
        save_param_00[9] = Globals.save_data->ply_saves[chr_id].base_mp;
        if (chr_id == 7 && aeon == 0x0D) {
            *save_param_00 = 0;
            save_param_00[1] = 0;
            // Removed Strength & Defense scalings - Anima was too overpowered with them
            // when using Seymour's stats as a base.
        }
        else {
            *save_param_00 = Globals.save_data->ply_saves[chr_id].base_strength;
            save_param_00[1] = Globals.save_data->ply_saves[chr_id].base_defense;
        }
        save_param_00[2] = Globals.save_data->ply_saves[chr_id].base_magic;
        save_param_00[3] = Globals.save_data->ply_saves[chr_id].base_magic_defense;
        save_param_00[4] = Globals.save_data->ply_saves[chr_id].base_agility;
        save_param_00[5] = Globals.save_data->ply_saves[chr_id].base_luck;
        save_param_00[6] = Globals.save_data->ply_saves[chr_id].base_evasion;
        save_param_00[7] = Globals.save_data->ply_saves[chr_id].base_accuracy;
        if (pMVar1 != (SphereGridPlyParam*)0x0) {
            save_param_00[8] = save_param_00[8] + pMVar1->hp * 0x32;
            save_param_00[9] = save_param_00[9] + pMVar1->mp * 5;
            *save_param_00 = *save_param_00 + pMVar1->strength;
            save_param_00[1] = save_param_00[1] + pMVar1->defense;
            save_param_00[2] = save_param_00[2] + pMVar1->magic;
            save_param_00[3] = save_param_00[3] + pMVar1->magic_defense;
            save_param_00[4] = save_param_00[4] + pMVar1->agility;
            save_param_00[5] = save_param_00[5] + pMVar1->luck;
            save_param_00[6] = save_param_00[6] + pMVar1->evasion;
            save_param_00[7] = save_param_00[7] + pMVar1->accuracy;
        }
        return (int*)pMVar1;
    }
}
