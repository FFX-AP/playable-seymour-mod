// SPDX-License-Identifier: MIT

namespace Fahrenheit.Mods.Seymour;

[FhLoad(FhGameId.FFX)]
public unsafe partial class SeymourModule : FhModule {
    static SeymourModule() {
        string text = "-----";
        ReadOnlySpan<byte> textUtf8 = Encoding.UTF8.GetBytes(text);
        textString = (byte*)NativeMemory.AllocZeroed((nuint)textUtf8.Length + 1);
        textUtf8.CopyTo(new Span<byte>(textString, textUtf8.Length));

        for (int i = 0; i < seymour_gear_names.Length; i++) {
            ReadOnlySpan<byte> weapon_name_utf8 = Encoding.UTF8.GetBytes(_seymour_gear_names[i]);
            int weapon_name_len = FhEncoding.compute_encode_buffer_size(weapon_name_utf8);
            void* name_ptr = NativeMemory.AllocZeroed((nuint)weapon_name_len + 1);
            _ = FhEncoding.encode(weapon_name_utf8, new(name_ptr, weapon_name_len));
            seymour_gear_names[i] = (nint)name_ptr;
        }
    }


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CT_RetInt_0171_fillPartyMemberHp(AtelBasicWorker* work, int* storage, AtelStack* stack);
    private static FhMethodHandle<CT_RetInt_0171_fillPartyMemberHp> _CT_RetInt_0171_fillPartyMemberHp
        => new(new FhMethodLocation("FFX.exe", 0x45C4F0));


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CT_RetInt_0172_fillPartyMemberMp(AtelBasicWorker* work, int* storage, AtelStack* stack);
    private static FhMethodHandle<CT_RetInt_0172_fillPartyMemberMp> _CT_RetInt_0172_fillPartyMemberMp
        => new(new FhMethodLocation("FFX.exe", 0x45C6B0));


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte AtelPushMember();
    private static FhMethodHandle<AtelPushMember> _AtelPushMember
        => new(new FhMethodLocation("FFX.exe", 0x46E2A0));


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte AtelPopMember();
    private static FhMethodHandle<AtelPopMember> _AtelPopMember
        => new(new FhMethodLocation("FFX.exe", 0x46DD40));


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MsSetSaveStartGame();
    private static FhMethodHandle<MsSetSaveStartGame> _MsSetSaveStartGame
        => new(new FhMethodLocation("FFX.exe", 0x386BC0));


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MsBtlReadManage();
    private static FhMethodHandle<MsBtlReadManage> _MsBtlReadManage
        => new(new FhMethodLocation("FFX.exe", 0x3830D0));


    private ushort* _NkSeymourLegend = FhUtil.ptr_at<ushort>(0x00886D80);


    public override bool init(FhModContext mod_context, FileStream global_state_file) {
        _NkSeymourLegend[0] = 0x8019; // Break Damage Limit
        _NkSeymourLegend[1] = 0x800F; // Triple Overdrive
        _NkSeymourLegend[2] = 0x8006; // Magic Booster
        _NkSeymourLegend[3] = 0x800D; // One MP Cost

        return _CT_RetInt_0171_fillPartyMemberHp.hook(this, h_CT_RetInt_0171_fillPartyMemberHp)
            && _CT_RetInt_0172_fillPartyMemberMp.hook(this, h_CT_RetInt_0172_fillPartyMemberMp)
            && _AtelPushMember                  .hook(this, h_AtelPushMember)
            && _AtelPopMember                   .hook(this, h_AtelPopMember)
            && _MsSetSaveStartGame              .hook(this, h_MsSetSaveStartGame)
            && _MsBtlReadManage                 .hook(this, h_MsBtlReadManage)
            && _TkMenuDrawMain                  .hook(this, h_TkMenuDrawMain)
            && _FUN_008c0220                    .hook(this, h_FUN_008c0220)
            && _FUN_008bc300                    .hook(this, h_FUN_008bc300)
            && _FUN_008e67f0                    .hook(this, h_FUN_008e67f0)
            && _DrawCrossMenuIconWeaponName2    .hook(this, h_DrawCrossMenuIconWeaponName2)
            && _TOBtlDrawCommandWindow          .hook(this, h_TOBtlDrawCommandWindow)
            && _FUN_008d85f0                    .hook(this, h_FUN_008d85f0)
            && _MsWeaponName                    .hook(this, h_MsWeaponName)
            && _FUN_008cf800                    .hook(this, h_FUN_008cf800)
            && _BattleRewards_AddGear           .hook(this, h_BattleRewards_AddGear)
            && _MsChangeWeaponInvisible         .hook(this, h_MsChangeWeaponInvisible)
            && _FUN_00635c20                    .hook(this, h_FUN_00635c20)
            && _MsLimitTypeDamageCheck          .hook(this, h_MsLimitTypeDamageCheck)
            && _MsLimitTypeDeathCheck           .hook(this, h_MsLimitTypeDeathCheck)
            && _FUN_007b10d0                    .hook(this, h_FUN_007b10d0)
            && _MsLimitTypeTurnCheck            .hook(this, h_MsLimitTypeTurnCheck)
            && _MsLimitTypeWinCheck             .hook(this, h_MsLimitTypeWinCheck)
            && _MsParseCommand                  .hook(this, h_MsParseCommand)
            && _TOBtlCtrlHelpWin                .hook(this, h_TOBtlCtrlHelpWin)
            && _TOGetSaveWindow                 .hook(this, h_TOGetSaveWindow)
            && _TkMenuSummonEnableMask          .hook(this, h_TkMenuSummonEnableMask)
            && _MsSetSaveParam                  .hook(this, h_MsSetSaveParam)
            && _MsGetChrAbilityMap              .hook(this, h_MsGetChrAbilityMap);
    }
    public override void load_local_state(FileStream? local_state_file, FhLocalStateInfo local_state_info) { }
    public override void save_local_state(FileStream local_state_file)                                     { }

    // If Kimahri gets restored, so does Seymour
    int h_CT_RetInt_0171_fillPartyMemberHp(AtelBasicWorker* work, int* storage, AtelStack* stack) {
        int ply_id;
        PlySave* ply_save;
        PlySave* seymour;

        ply_id = FhXCall.AtelPopStackInteger.fnptr!(work, stack);
        ply_save = FhXCall.MsGetSavePlayerPtr.fnptr!(ply_id);
        ply_save->battles_until_recovery = 0;
        if (ply_id == 3) {
            seymour = FhXCall.MsGetSavePlayerPtr.fnptr!(7);
            seymour->battles_until_recovery = 0;
            seymour->hp = seymour->max_hp;
        }
        if (ply_save->max_hp < ply_save->hp) {
            return (int)ply_save->hp;
        }
        ply_save->hp = ply_save->max_hp;
        return (int)ply_save->max_hp;
    }

    int h_CT_RetInt_0172_fillPartyMemberMp(AtelBasicWorker* work, int* storage, AtelStack* stack) {
        int ply_id;
        PlySave* ply_save;
        PlySave* seymour;

        ply_id = FhXCall.AtelPopStackInteger.fnptr!(work, stack);
        ply_save = FhXCall.MsGetSavePlayerPtr.fnptr!(ply_id);
        if (ply_id == 3) {
            seymour = FhXCall.MsGetSavePlayerPtr.fnptr!(7);
            seymour->mp = seymour->max_mp;
        }
        if (ply_save->max_mp < ply_save->mp) {
            return (int)ply_save->mp;
        }
        ply_save->mp = ply_save->max_mp;
        return (int)ply_save->max_mp;
    }

    // Save Party Lineup
    byte h_AtelPushMember() {
        byte bVar1;
        SaveData* pSVar2;
        uint uVar3;
        byte* puVar4;
        uint* puVar5;
        int iVar6;
        uint uVar7;
        int ply_id;
        uint* local_14 = stackalloc uint[4];

        pSVar2 = FhXCall.MsGetSaveEventAddress.fnptr!();
        bVar1 = pSVar2->atel_is_push_member;
        FhXCall.MsGetSavePartyMember.fnptr!(local_14, local_14 + 1, local_14 + 2);
        puVar4 = &pSVar2->atel_push_frontline[0];
        puVar5 = local_14;
        iVar6 = 3;
        do {
            if (*puVar5 == 0xff) {
                *puVar4 = 0xff;
            }
            else {
                *puVar4 = (byte)*puVar5;
            }
            puVar5 = puVar5 + 1;
            puVar4 = puVar4 + 1;
            iVar6 = iVar6 + -1;
        } while (iVar6 != 0);
        ply_id = 0;
        *(int*)&pSVar2->atel_push_party = 0;
        uVar7 = 1;
        do {
            uVar3 = FhXCall.MsGetSavePlyJoin.fnptr!((byte)ply_id);
            if (uVar3 == 1) {
                *(uint*)&pSVar2->atel_push_party = *(uint*)&pSVar2->atel_push_party | uVar7;
            }
            uVar7 = uVar7 << 1 | (uint)((int)uVar7 < 0 ? 1 : 0);
            ply_id = ply_id + 1;
        } while (ply_id < 8);
        pSVar2->atel_is_push_member = 1;
        return bVar1;
    }

    // Restore Party Lineup
    byte h_AtelPopMember() {
        byte bVar1;
        byte bVar2;
        SaveData* pSVar3;
        byte bVar4;
        byte bVar5;
        int iVar6;
        uint uVar7;

        pSVar3 = FhXCall.MsGetSaveEventAddress.fnptr!();
        bVar1 = pSVar3->atel_is_push_member;
        if (bVar1 != 0) {
            iVar6 = 0;
            uVar7 = 1;
            do {
                FhXCall.MsSetSavePlyJoin.fnptr!(iVar6, (int)(((*(uint*)&pSVar3->atel_push_party & uVar7) != 0) ? 1u : 0u));
                uVar7 = uVar7 << 1 | (uint)((int)uVar7 < 0 ? 1 : 0);
                iVar6 = iVar6 + 1;
            } while (iVar6 < 8);
            bVar5 = pSVar3->atel_push_frontline[0];
            if (bVar5 == 0xff) {
                bVar5 = 0xff;
            }
            bVar4 = pSVar3->atel_push_frontline[1];
            if (bVar4 == 0xff) {
                bVar4 = 0xff;
            }
            bVar2 = pSVar3->atel_push_frontline[2];
            if (bVar2 == 0xff) {
                bVar2 = 0xff;
            }
            FhGCall.MsSetSavePartyMember.fnptr!(bVar5, bVar4, bVar2);
        }
        pSVar3->atel_is_push_member = 0;
        return bVar1;
    }

    // On New Game, initialise Seymour
    void h_MsSetSaveStartGame() {
        _MsSetSaveStartGame.chain_from(h_MsSetSaveStartGame).fnptr!();

        Globals.save_data->ability_map_limit.has_extra_24 = true;

        for (int i = 0; i < 200; i++) {
            Equipment* gear = &Globals.save_data->equipment[i];
            if (gear->exists && gear->owner == 7) {
                gear->flags = 2;
                if (gear->type == 1) {
                    gear->slot_count = 1;
                    gear->abilities[0] = 0xFF;
                    gear->name_id = FhXCall.MsWeaponNameNum.fnptr!(gear);
                }
                else {
                    gear->slot_count = 2;
                    gear->abilities[1] = 0x8000;
                    gear->name_id = FhXCall.MsWeaponNameNum.fnptr!(gear);
                }
                _MsWeaponName.fnptr!(gear->name_id, gear->owner, false, &gear->model_id);
            }
        }

        PlySave* seymour = FhXCall.MsGetSavePlayerPtr.fnptr!(7);
        seymour->base_mp = 319;
        seymour->mp = 319;
        seymour->max_mp = 319;
        seymour->base_defense = 17;
        seymour->base_magic = 32;
        seymour->base_magic_defense = 40;
        seymour->base_agility = 15;
        seymour->base_evasion = 3;
        seymour->slv_spent = 30;
        seymour->abi_map.has_weapon_change = true;
        seymour->abi_map.has_armor_change = true;
        seymour->limit_mode_ctr_warrior = 150;
        seymour->limit_mode_ctr_comrade = 240;
        seymour->limit_mode_ctr_healer = 100;
        seymour->limit_mode_ctr_tactician = 75;
        seymour->limit_mode_ctr_victim = 80;
        seymour->limit_mode_ctr_dancer = 200;
        seymour->limit_mode_ctr_avenger = 160;
        seymour->limit_mode_ctr_slayer = 115;
        seymour->limit_mode_ctr_hero = 70;
        seymour->limit_mode_ctr_rook = 110;
        seymour->limit_mode_ctr_victor = 180;
        seymour->limit_mode_ctr_coward = 700;
        seymour->limit_mode_ctr_ally = 320;
        seymour->limit_mode_ctr_sufferer = 65;
        seymour->limit_mode_ctr_daredevil = 150;
        seymour->limit_mode_ctr_loner = 30;
        seymour->obtained_limit_modes = (OverdriveModeFlags)(uint)OverdriveModeFlags.STOIC;
        _MsSetSaveParam.fnptr!(7);

        Command* requiem = (Command*)FhXCall.MsGetRomPlyCommand.fnptr!(0x30E3, (int*)0x0);
        requiem->is_piercing = true;
        requiem->flags_damage = 4; // Can Crit
        requiem->dmg_formula = 15; // Special MAG
        requiem->power = 45;

        Command* extra24 = (Command*)FhXCall.MsGetRomPlyCommand.fnptr!(0x3130, (int*)0x0);
        extra24->name.standard.text_offset = 12487; // "Summon"
        extra24->desc.standard.text_offset = 12496; // "Summon an aeon."
        extra24->icon = 19;
        extra24->is_top_level_in_menu = true;
        extra24->opens_sub_menu = true;
        extra24->sub_menu_cat2 = 5;
        extra24->sub_menu_cat = 5;
        extra24->user_id = 7;
        extra24->flags_target = 0;
        extra24->display_move_name = false;
        extra24->is_in_trigger_menu = true;
        extra24->show_user_casting_effects = true;
        extra24->limit_cost = 100;
    }

    // Prevent Softlocks
    void h_MsBtlReadManage() {
        int old_state = Globals.Battle.btl->battle_state;

        _MsBtlReadManage.chain_from(h_MsBtlReadManage).fnptr!();

        if (Globals.Battle.btl->battle_state != 13 || old_state == Globals.Battle.btl->battle_state) return;

        // Post Battle Start
        if (Globals.Battle.player_characters == null) return;

        FhXCall.FUN_0079b480.fnptr!(PlySaveId.PC_SEYMOUR, PlayerCommandId.PCOM_USE, 1);
        FhXCall.FUN_0079b480.fnptr!(PlySaveId.PC_SEYMOUR, PlayerCommandId.PCOM_SPARE_CHANGE, 1);
        FhXCall.FUN_0079b480.fnptr!(PlySaveId.PC_SEYMOUR, PlayerCommandId.PCOM_THREATEN, 1);
        FhXCall.FUN_0079b480.fnptr!(PlySaveId.PC_SEYMOUR, PlayerCommandId.PCOM_PROVOKE, 1);
        FhXCall.FUN_0079b480.fnptr!(PlySaveId.PC_SEYMOUR, PlayerCommandId.PCOM_BRIBE, 1);
    }
}