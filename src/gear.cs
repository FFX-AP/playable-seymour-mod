// SPDX-License-Identifier: MIT

namespace Fahrenheit.Mods.Seymour;

public unsafe partial class SeymourModule : FhModule {
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte* MsWeaponName(ushort name_id, byte owner, [MarshalAs(UnmanagedType.Bool)] bool simplified, ushort* out_model_id);
    private static FhMethodHandle<MsWeaponName> _MsWeaponName
        => new ( new FhMethodLocation("FFX.exe", 0x3A0C70) );
    private static nint[] seymour_gear_names = new nint[171];
    private static string[] _seymour_gear_names = [
        "Dimittis",            // Celestial
        "Scepter",             // Brotherhood
        "Subduing Scepter",    // Capture
        "Arcane Scepter",      // 4x Elemental Strikes
        "Heaven Fall",         // Break Damage Limit
        "Transcendence",       // Triple Overdrive + Triple AP + Overdrive > AP
        "Retribution",         // Triple Overdrive + Overdrive > AP
        "Deliverance",         // Double Overdrive + Double AP
        "Ferrier of Souls",    // Triple Overdrive
        "Veil Piercer",        // Double Overdrive
        "Benediction",         // Triple AP
        "Rite of the Guado",   // Double AP
        "Sublimator",          // Overdrive > AP
        "Fettered Malice",     // SOS Overdrive
        "Scepter",             // Dummy?
        "Astral Scepter",      // One MP Cost
        "Chaos Scepter",       // 4x Status Strikes
        "Scepter",             // Dummy?
        "Scepter",             // Dummy?
        "Master Scepter",      // 4x Strength Bonuses
        "Wizard's Scepter",    // 4x Magic Bonuses
        "Mana Scepter",        // 3x Magic +X%s + Magic Booster
        "Magistral Scepter",   // Half MP Cost
        "Resplendence",        // Gillionaire
        "Tri-Scepter",         // At least 3x Elemental Strikes
        "Malefic Scepter",     // At least 3x Status Strikes
        "Nemesis Scepter",     // Magic Counter + either Counterattack or Evade & Counter
        "Karmic Scepter",      // Either Counterattack or Evade & Counter
        "P-Scepter",           // Distill Power
        "M-Scepter",           // Distill Mana
        "S-Scepter",           // Distill Speed
        "A-Scepter",           // Distill Ability
        "Prism Scepter",       // Magic Counter
        "Mirage Scepter",      // Magic Booster
        "Thaumaturge",         // Alchemy
        "Sonic Scepter",       // First Strike
        "Quick Gambit",        // Initiative
        "Grim Embrace",        // Deathstrike
        "Halting Grace",       // Slowstrike
        "Earth Breaker",       // Stonestrike
        "Serpent's Fang",      // Poisonstrike
        "Eternal Slumber",     // Sleepstrike
        "Inhibitor",           // Silencestrike
        "Nightfall",           // Darkstrike
        "Monk's Scepter",      // At least 3x Strength +X%s
        "Priest's Scepter",    // At least 3x Magic +X%s
        "Dual Scepter",        // At least 2x Element Strikes
        "Ominous Scepter",     // At least 2x Status Touch's
        "Atrophy Scepter",     // Deathtouch
        "Languid Scepter",     // Slowtouch
        "Break Scepter",       // Stonetouch
        "Miasma Scepter",      // Poisontouch
        "Hypno Scepter",       // Sleeptouch
        "Tranquil Scepter",    // Silencetouch
        "Twilight Scepter",    // Darktouch
        "Scout Scepter",       // Sensor
        "Flame Scepter",       // Firestrike
        "Frost Scepter",       // Icestrike
        "Blitz Scepter",       // Lightningstrike
        "Flood Scepter",       // Waterstrike
        "Futile Scepter",      // 4x Empty Slots
        "Force Scepter",       // At least x1 Strength +X% and x1 Magic +X%
        "Vain Scepter",        // At least 2x Empty Slots
        "Sorcery Scepter",     // Magic +10% or Magic +20%
        "Decimator Scepter",   // Strength +10% or Strength +20%
        "Rune Scepter",        // Magic +5%
        "Enchanted Scepter",   // Magic +3%
        "Buster Scepter",      // Strength +5%
        "Ruin Scepter",        // Strength +3%
        "Spiked Scepter",      // Piercing
        "Scepter",             // Else
        "Scepter",             // Dummy?
        "Scepter",             // Dummy?
        "Scepter",             // Dummy?
        "Resolute",            // Break HP Limit + Break MP Limit
        "Arcane Circlet",      // Break HP Limit
        "Mythical Circlet",    // Break MP Limit
        "Crystal Circlet",     // 4x Element Eaters
        "Aegis Circlet",       // 4x Element Proofs
        "Unwavering",          // Auto-Reflect + Auto-Regen + Auto-Protect + Auto-Shell
        "Renatus",             // Auto-Phoenix + Auto-Med + Auto-Potion
        "Restorative Circlet", // Auto-Potion + Auto-Med
        "Omnis",               // 4x Status Proofs
        "Diamond Circlet",     // 4x Defense +X%s
        "Ruby Circlet",        // 4x Magic Def +X%s
        "Empowered Circlet",   // 4x HP +X%s
        "Magical Circlet",     // 4x MP +X%s
        "Collector Circlet",   // Master Thief
        "Treasure Circlet",    // Pickpocket
        "Circlet of Hope",     // HP Stroll + MP Stroll
        "Assault Circlet",     // 4x Auto's
        "Phantom Circlet",     // 3x Element Eaters
        "Recovery Circlet",    // HP Stroll
        "Spiritual Circlet",   // MP Stroll
        "Phoenix Circlet",     // Auto-Phoenix
        "Curative Circlet",    // Auto-Med
        "Rainbow Circlet",     // 4x SOS Nuls
        "Shining Circlet",     // 4x SOS'
        "Faerie Circlet",      // At least 3x Status Proofs
        "Peaceful Circlet",    // No Encounters
        "Shaman Circlet",      // Auto-Potion
        "Barrier Circlet",     // At least 3x Element Proofs
        "Star Circlet",        // At least 3x SOS'
        "Marching Circlet",    // At least 2x Auto's
        "Moon Circlet",        // At least 2x SOS'
        "Regen Circlet",       // Auto-Regen or SOS Regen
        "Haste Circlet",       // Auto-Haste or SOS Haste
        "Reflect Circlet",     // Auto-Reflect or SOS Reflect
        "Shell Circlet",       // Auto-Shell or SOS Shell
        "Protect Circlet",     // Auto-Protect or SOS Protect
        "Circlet",             // Alchemy
        "Platinum Circlet",    // At least 3x Defense +X%s
        "Sapphire Circlet",    // At least 3x Magic Def +X%s
        "Power Circlet",       // At least 3x HP +X%s
        "Wizard Circlet",      // At least 3x MP +X%s
        "Elemental Circlet",   // At least 2x Elemental Proofs or Eaters
        "Savior Circlet",      // At least 2x Status Proofs
        "Crimson Circlet",     // Fire Eater
        "Snow Circlet",        // Ice Eater
        "Ochre Circlet",       // Lightning Eater
        "Cerulean Circlet",    // Water Eater
        "Medical Circlet",     // Curseproof or Curse Ward
        "Lucid Circlet",       // Confuseproof or Confuse Ward
        "Serene Circlet",      // Berserkproof or Berserk Ward
        "Light Circlet",       // Slowproof or Slow Ward
        "Soul Circlet",        // Deathproof or Death Ward
        "Blessed Circlet",     // Zombieproof or Zombie Ward
        "Soft Circlet",        // Stoneproof or Stone Ward
        "Serum Circlet",       // Poisonproof or Poison Ward
        "Alert Circlet",       // Sleepproof or Sleep Ward
        "Echo Circlet",        // Silenceproof or Silence Ward
        "Bright Circlet",      // Darkproof or Dark Ward
        "Red Circlet",         // Fireproof or Fire Ward
        "White Circlet",       // Iceproof or Ice Ward
        "Yellow Circlet",      // Lightningproof or Lightning Ward
        "Blue Circlet",        // Waterproof or Water Ward
        "NulTide Circlet",     // SOS NulTide
        "NulBlaze Circlet",    // SOS NulBlaze
        "NulShock Circlet",    // SOS NulShock
        "NulFrost Circlet",    // SOS NulFrost
        "Adept's Circlet",     // 4x HP +X%s or MP +X%s
        "Tetra Circlet",       // 4x Empty Slots
        "Mythril Circlet",     // At least 1 Def +X% and 1 Magic Def +X%
        "Gold Circlet",        // At least 2x Def +X%s
        "Emerald Circlet",     // At least 2x Magic Def +X%s
        "Vita Circlet",        // At least 2x HP +X%s
        "Mage's Circlet",      // At least 2x MP +X%s
        "Silver Circlet",      // Def +10% or Def +20%
        "Onyx Circlet",        // Magic Def +10% or Magic Def +20%
        "Sorcery Circlet",     // MP +20% or MP +30%
        "Tough Circlet",       // HP +20% or MP + 20%
        "Glorious Circlet",    // 3x Empty Slots
        "Metal Circlet",       // Def +3% or Def + 5%
        "Pearl Circlet",       // Magic Def +3% or Magic Def + 5%
        "Magic Circlet",       // MP +5% or MP + 10%
        "Seeker's Circlet",    // HP +5% or HP + 10%
        "Guardian Circlet",    // 2x Empty Slots
        "Circlet",             // Else
        "Absolution",          // Ribbon
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "Circlet",             // Dummy?
        "-",                   // Dummy?
    ];


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_008cf800(void* param_1);
    private static FhMethodHandle<FUN_008cf800> _FUN_008cf800
        => new ( new FhMethodLocation("FFX.exe", 0x4CF800) );
    private int* p_DAT_0186a5ec    => FhUtil.ptr_at<int>(0x0146A5EC);
    private int* p_DAT_0186a5f0    => FhUtil.ptr_at<int>(0x0146A5F0);
    private int* p_TKMenuFaceRatio => FhUtil.ptr_at<int>(0x01FCC3C8);
    private int* p_TkMenuFaceKeep  => FhUtil.ptr_at<int>(0x01FCC3C4);
    private int* p_TkMenuFaceNew   => FhUtil.ptr_at<int>(0x01FCC3C0);
    private int* p_TkMenuFaceOld   => FhUtil.ptr_at<int>(0x01FCC3BC);
    private int* p_DAT_0186a634    => FhUtil.ptr_at<int>(0x0146A634);
    private int* p_DAT_0186a614    => FhUtil.ptr_at<int>(0x0146A614);
    private int* p_DAT_0186a654    => FhUtil.ptr_at<int>(0x0146A654);
    private int* p_DAT_0186a674    => FhUtil.ptr_at<int>(0x0146A674);
    private int* p_DAT_0186a5e4    => FhUtil.ptr_at<int>(0x0146A5E4);
    private int* p_DAT_0186a5d8    => FhUtil.ptr_at<int>(0x0146A5D8);
    private int* p_DAT_0186a5d4    => FhUtil.ptr_at<int>(0x0146A5D4);


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int BattleRewards_AddGear(int chr_id, ChrLoot* loot, BtlRewardData* rewards);
    private static FhMethodHandle<BattleRewards_AddGear> _BattleRewards_AddGear
        => new ( new FhMethodLocation("FFX.exe", 0x398C20) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MsChangeWeaponInvisible(int ply_id, bool enable);
    private static FhMethodHandle<MsChangeWeaponInvisible> _MsChangeWeaponInvisible
        => new ( new FhMethodLocation("FFX.exe", 0x3AD5F0) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_008c94b0();
    private static FhMethodHandle<FUN_008c94b0> _FUN_008c94b0
        => new ( new FhMethodLocation("FFX.exe", 0x4C94B0) );
    public int[] character_gear_count = new int[16];


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_008c9bc0();
    private static FhMethodHandle<FUN_008c9bc0> _FUN_008c9bc0
        => new ( new FhMethodLocation("FFX.exe", 0x4C9BC0) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUN_008c9f80();
    private static FhMethodHandle<FUN_008c9f80> _FUN_008c9f80
        => new ( new FhMethodLocation("FFX.exe", 0x4C9F80) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUN_008ca180();
    private static FhMethodHandle<FUN_008ca180> _FUN_008ca180
        => new ( new FhMethodLocation("FFX.exe", 0x4CA180) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool FUN_00635c20(uint param_1);
    private static FhMethodHandle<FUN_00635c20> _FUN_00635c20
        => new ( new FhMethodLocation("FFX.exe", 0x235C20) );
    private int g_eventId => FhUtil.get_at<int>(0x00EFBBF8);



    // Seymour Gear Names
    byte* h_MsWeaponName(ushort name_id, byte owner, [MarshalAs(UnmanagedType.Bool)] bool simplified, ushort* out_model_id) {
        if (owner != 7) {
            return _MsWeaponName.chain_from(h_MsWeaponName).fnptr!(name_id, owner, simplified, out_model_id);
        }
        int gearid = name_id & 0xFFF;
        if (out_model_id is not null) {
            if (gearid >= 74) { // Start of Armor IDs
                *out_model_id = 0x4067; // Seymour Armor
            }
            else {
                *out_model_id = 0x4066; // Seymour Staff
            }
        }
        if (gearid > seymour_gear_names.Length - 1) {
            return _MsWeaponName.chain_from(h_MsWeaponName).fnptr!(name_id, owner, simplified, out_model_id);
        }
        return (byte*)seymour_gear_names[gearid];
    }

    // HP/MP Copying for Equip Menu
    void h_FUN_008cf800(void* param_1) {
        bool bVar1;
        int iVar2;
        int ply_id;
        int iVar4;

        int param_1_00 = (int)param_1;
        *(int*)(param_1_00 + 0x1c) = 0;
        *p_DAT_0186a5ec = 0;
        *p_DAT_0186a5f0 = 0xff;
        *p_TKMenuFaceRatio = 0;
        *p_TkMenuFaceKeep = FhXCall.TkMenuGetCurrentPlayerPos.fnptr!();
        *p_TkMenuFaceNew = FhXCall.TkMenuGetCurrentPlayerPos.fnptr!();
        *p_TkMenuFaceOld = FhXCall.TkMenuGetCurrentPlayerPos.fnptr!();
        ply_id = 0;
        do {
            iVar2 = FhXCall.FUN_008a97d0.fnptr!(ply_id);
            p_DAT_0186a634[ply_id] = iVar2;
            iVar2 = FhXCall.FUN_008a9c20.fnptr!(ply_id);
            p_DAT_0186a614[ply_id] = iVar2;
            iVar2 = (int)FhXCall.TkMenuGetHP.fnptr!(ply_id);
            p_DAT_0186a654[ply_id] = iVar2;
            iVar2 = (int)FhXCall.TkMenuGetMP.fnptr!(ply_id);
            p_DAT_0186a674[ply_id] = iVar2;
            ply_id = ply_id + 1;
        } while (ply_id < 8);
        *p_DAT_0186a5e4 = 0;
        bVar1 = FhXCall.FUN_008cfc00.fnptr!();
        iVar4 = bVar1 ? 1 : 0;
        iVar2 = FhXCall.TkMenuGetCurrentPlayer.fnptr!();
        FhXCall.FUN_008cfcf0.fnptr!(iVar2, iVar4);
        *p_DAT_0186a5d8 = 0x155;
        *p_DAT_0186a5d4 = 0;
        return;
    }

    // Battle Results: Equipment Drops
    int h_BattleRewards_AddGear(int chr_id, ChrLoot* loot, BtlRewardData* rewards) {
        bool bVar1;
        byte ply_id;
        ushort uVar2;
        int iVar3;
        uint uVar5;
        uint uVar6;
        int iVar7;
        int iVar8;
        ushort* puVar9;
        int iVar10;
        int iVar11;
        ushort* puVar12;
        int local_14;
        ushort* local_c;
        uint gear_owner;

        iVar3 = FhXCall.FUN_00798be0.fnptr!(rewards);
        if (iVar3 < 0) {
            return -1;
        }
        rewards->gear[iVar3].exists = true;
        rewards->gear[iVar3].flags = 0;
        iVar7 = 0;
        iVar10 = 0;
        do {
            bVar1 = FhXCall.MsGetSavePlyJoined.fnptr!((byte)iVar7);
            if (bVar1) {
                iVar10 = iVar10 + 1;
            }
            iVar7 = iVar7 + 1;
        } while (iVar7 < 8);
        if (chr_id < 8) {
            iVar10 = iVar10 + 3;
        }
        else {
            chr_id = 0;
        }
        iVar7 = FhGCall.brnd.fnptr!(0xc);
        iVar11 = 0;
        iVar8 = 0;
        do {
            ply_id = (byte)iVar8;
            bVar1 = FhXCall.MsGetSavePlyJoined.fnptr!(ply_id);
            if (bVar1) {
                iVar11 += 1;
                if (iVar7 % iVar10 < iVar11) goto LAB_00798cb8;
            }
            iVar8 = iVar8 + 1;
        } while (iVar8 < 8);
        ply_id = (byte)chr_id;
    LAB_00798cb8:
        rewards->gear[iVar3].owner = ply_id;
        iVar7 = FhGCall.brnd.fnptr!(0xc);
        rewards->gear[iVar3].type = (byte)((byte)iVar7 & 1);
        rewards->gear[iVar3].equipped_by = 0xff;
        rewards->gear[iVar3].dmg_formula = loot->equipment_loot.dmg_formula;
        rewards->gear[iVar3].power = loot->equipment_loot.power;
        rewards->gear[iVar3].crit_bonus = loot->equipment_loot.crit_bonus;
        uVar5 = (uint)FhGCall.brnd.fnptr!(0xc);
        uVar6 = (uint)FhGCall.brnd.fnptr!(0xc);
        iVar7 = (int)(loot->equipment_loot.slot_count + ((uVar5 & 7) - 4));
        iVar7 = int.Clamp((int)(iVar7 + (iVar7 >> 0x1f & 3U)) >> 2, 1, 4);
        rewards->gear[iVar3].slot_count = (byte)iVar7;
        iVar10 = (int)(loot->equipment_loot.ability_count + ((uVar6 & 7) - 4));
        gear_owner = rewards->gear[iVar3].owner;
        if (gear_owner == 7) {
            gear_owner = 3; // Checks if the gear rng rolled belongs to Seymour,
                            // and assigns the gear's auto-abilities to another character's field.
                            // (here, Seymour gets Kimahri's auto-abilities)
        }
        puVar12 = (ushort*)((&loot->equipment_loot.abilities_tidus) + gear_owner) + (uint)rewards->gear[iVar3].type * 8;
        local_14 = (int)(iVar10 + (iVar10 >> 0x1f & 7U)) >> 3;
        uVar2 = *puVar12;
        fixed (Equipment* gear = &rewards->gear[iVar3]) {
            if (((byte)iVar7 == 0) || (uVar2 == 0)) {
                iVar3 = 0;
            }
            else {
                gear->abilities[0] = uVar2;
                iVar3 = 1;
            }
            if (0 < local_14) {
                local_c = &gear->abilities[0] + iVar3;
                do {
                    if ((int)(uint)gear->slot_count <= iVar3) break;
                    iVar7 = FhGCall.brnd.fnptr!(0xd);
                    uVar2 = puVar12[iVar7 % 7 + 1];
                    if (uVar2 != 0) {
                        iVar7 = FhXCall.FUN_00798aa0.fnptr!(uVar2);
                        iVar10 = 0;
                        if (0 < iVar3) {
                            puVar9 = &gear->abilities[0];
                            do {
                                iVar8 = FhXCall.FUN_00798aa0.fnptr!(*puVar9);
                                if (iVar8 == iVar7) goto LAB_00798e2c;
                                iVar10 = iVar10 + 1;
                                puVar9 = puVar9 + 1;
                            } while (iVar10 < iVar3);
                        }
                        *local_c = uVar2;
                        iVar3 = iVar3 + 1;
                        local_c = local_c + 1;
                    }
                LAB_00798e2c:
                    local_14 = local_14 + -1;
                } while (0 < local_14);
            }
            if (iVar3 < 4) {
                puVar12 = &gear->abilities[0] + iVar3;
                for (uVar5 = (uint)(4U - iVar3 >> 1); uVar5 != 0; uVar5 = uVar5 - 1) {
                    *(uint*)puVar12 = 0x00FF00FF;
                    puVar12 = puVar12 + 2;
                }
                for (uVar5 = (uint)((4U - iVar3 & 1) != 0 ? 1 : 0); uVar5 != 0; uVar5 = uVar5 - 1) {
                    *puVar12 = 0xff;
                    puVar12 = puVar12 + 1;
                }
            }
            uVar2 = FhXCall.MsWeaponNameNum.fnptr!(gear);
            gear->name_id = uVar2;
            _MsWeaponName.fnptr!(uVar2, gear->owner, false, &gear->model_id);
        }
        return 0;
    }

    // Show Gear in Menus
    void h_MsChangeWeaponInvisible(int ply_id, bool enable) {
        Equipment* gear;
        int type;
        int ply_id_00;
        byte inv_idx;

        ply_id_00 = ply_id & 0xff;
        if (ply_id_00 < 8) {
            type = 0;
            do {
                if (type == 0) {
                    inv_idx = Globals.save_data->ply_saves[ply_id_00].wpn_inv_idx;
                }
                else {
                    inv_idx = Globals.save_data->ply_saves[ply_id_00].arm_inv_idx;
                }
                if (inv_idx != 0xff) {
                    gear = FhXCall.MsGetSaveWeapon.fnptr!(inv_idx, 0x0);
                    gear->flags = (byte)(gear->flags ^ (enable ? 1 : 0 * 2 ^ gear->flags) & 2);
                }
                type = type + 1;
            } while (type < 2);
        }
        return;
    }

    // Sort Seymour's Gear in Inventory
    void h_FUN_008c94b0() {
        int iVar1;
        Equipment* pEVar2;
        int iVar3;
        byte* local_8;
        int index;

        iVar1 = _FUN_008c1ba0.fnptr!();
        iVar3 = 0;
        Array.Clear(character_gear_count, 0, character_gear_count.Length);
        if (0 < iVar1) {
            do {
                pEVar2 = FhXCall.MsGetSaveWeapon.fnptr!(p_TkMenuItemData_ARRAY_01597730[iVar3].item_id, (nint)(&local_8));
                if (pEVar2->owner < 8) {
                    index = (pEVar2->type != 0 ? 1 : 0) + pEVar2->owner * 2;
                    character_gear_count[index] = character_gear_count[index] + 1;
                }
                iVar3 = iVar3 + 1;
            } while (iVar3 < iVar1);
        }
        return;
    }

    void h_FUN_008c9bc0() {
        ushort uVar1;
        int iVar2;
        int puVar3;
        int local_8;

        iVar2 = 0;
        puVar3 = 0;
        do {
            local_8 = 2;
            do {
                uVar1 = (ushort)character_gear_count[puVar3];
                _FUN_008c9c10.fnptr!((int)p_TkMenuItemData_ARRAY_01597730, iVar2, uVar1);
                iVar2 = (int)(iVar2 + (uint)uVar1);
                puVar3 = puVar3 + 1;
                local_8 = local_8 + -1;
            } while (local_8 != 0);
        } while (puVar3 < 16);
        return;
    }

    int h_FUN_008c9f80() {
        int iVar1;
        Equipment* pEVar2;
        int iVar3;
        TkMenuItemData* pTVar4;
        int iVar5;
        int iVar6;
        uint uVar7;
        byte* local_424;
        int local_420;
        int local_41c;
        int local_418;
        int local_414;
        uint local_410;
        byte* local_40c;
        byte* local_408 = stackalloc byte[1024];

        local_40c = (byte*)0x0;
        iVar1 = _FUN_008c1ba0.fnptr!();
        iVar3 = 0;
        local_418 = iVar1;
        if (0 < iVar1) {
            do {
                pEVar2 = FhXCall.MsGetSaveWeapon.fnptr!(p_TkMenuItemData_ARRAY_01597730[iVar3].item_id, (nint)(&local_424));
                iVar5 = iVar3 + 1;
                local_408[iVar3] = pEVar2->owner;
                iVar3 = iVar5;
            } while (iVar5 < iVar1);
        }
        uVar7 = 0;
        iVar3 = 0;
        do {
            iVar5 = (int)((uint)character_gear_count[(int)(uVar7 * 2 + 1)] + (uint)character_gear_count[(int)(uVar7 * 2)]);
            iVar6 = 0;
            local_414 = iVar5 + iVar3;
            iVar1 = local_414 + -1;
            if (iVar5 != 0) {
                pTVar4 = p_TkMenuItemData_ARRAY_01597730 + iVar3;
                local_40c = local_408 + (int)local_40c;
                local_420 = iVar5;
                do {
                    local_410 = local_40c[iVar6];
                    if (local_410 != uVar7) {
                        local_41c = _FUN_008c9b90.fnptr!(local_408, (byte)uVar7, iVar1 + 1, local_418);
                        if (local_41c < 0) {
                            return 0;
                        }
                        _FUN_007aba10.fnptr!(pTVar4->item_id, p_TkMenuItemData_ARRAY_01597730[local_41c].item_id);
                        local_40c[iVar6] = local_408[local_41c];
                        local_408[local_41c] = (byte)local_410;
                        iVar1 = local_41c;
                        iVar5 = local_420;
                    }
                    iVar6 = iVar6 + 1;
                    pTVar4 = pTVar4 + 1;
                } while (iVar6 < iVar5);
            }
            uVar7 = uVar7 + 1;
            iVar3 = local_414;
            local_40c = (byte*)local_414;
        } while ((int)uVar7 < 8);
        return 1;
    }

    int h_FUN_008ca180() {
        int iVar1;
        Equipment* pEVar2;
        uint uVar3;
        int iVar4;
        TkMenuItemData* pTVar5;
        byte* local_424;
        int local_420;
        uint local_41c;
        byte* local_418;
        int local_410;
        byte local_409;
        byte* local_408 = stackalloc byte[1024];
        int chr_id;
        int weapon_count;
        int armor_count;

        iVar1 = _FUN_008c1ba0.fnptr!();
        iVar4 = 0;
        local_420 = iVar1;
        if (0 < iVar1) {
            do {
                pEVar2 = FhXCall.MsGetSaveWeapon.fnptr!(p_TkMenuItemData_ARRAY_01597730[iVar4].item_id, (nint)(&local_424));
                local_408[iVar4] = (byte)(pEVar2->type != 0 ? 1 : 0);
                iVar4 = iVar4 + 1;
            } while (iVar4 < iVar1);
        }
        local_410 = 0;
        chr_id = 0;
        do {
            weapon_count = character_gear_count[chr_id * 2];
            armor_count = character_gear_count[chr_id * 2 + 1];
            uVar3 = (uint)weapon_count;
            iVar1 = (int)(local_410 + -1 + uVar3);
            iVar4 = 0;
            if (uVar3 != 0) {
                pTVar5 = p_TkMenuItemData_ARRAY_01597730 + local_410;
                local_418 = local_408 + local_410;
                local_41c = uVar3;
                do {
                    local_409 = local_418[iVar4];
                    if (local_409 != 0) {
                        iVar1 = _FUN_008c9b90.fnptr!(local_408, 0, iVar1 + 1, local_420);
                        if (iVar1 < 0) {
                            return 0;
                        }
                        _FUN_007aba10.fnptr!(pTVar5->item_id, p_TkMenuItemData_ARRAY_01597730[iVar1].item_id);
                        local_418[iVar4] = local_408[iVar1];
                        local_408[iVar1] = local_409;
                        uVar3 = local_41c;
                    }
                    iVar4 = iVar4 + 1;
                    pTVar5 = pTVar5 + 1;
                } while (iVar4 < (int)uVar3);
            }
            local_410 = (int)(local_410 + armor_count + uVar3);
            chr_id++;
        } while (chr_id < 8);
        return 1;
    }

    // Show Seymour's Armor Model
    bool h_FUN_00635c20(uint param_1) {
        ushort story_progress = FhXCall.getScenerioFlag.fnptr!();
        if (param_1 != 0x4068) {
            if (story_progress == 0x2e) {
                if ((param_1 != 5) && (param_1 != 6) && (param_1 != 0x109b) && param_1 != 0x5001 && (param_1 != 0x5002)) {
                    return false;
                }
            }
            else {
                if (g_eventId != 0x17e) {
                    return false;
                }
                if (0x3fff < (int)(param_1 & 0xfffff000)) {
                    return false;
                }
            }
        }
        return true;
    }
}