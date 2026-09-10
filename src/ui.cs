// SPDX-License-Identifier: MIT

namespace Fahrenheit.Mods.Seymour;

public unsafe partial class SeymourModule : FhModule {
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuDrawMain(void* menu);
    private static FhMethodHandle<TkMenuDrawMain> _TkMenuDrawMain
        => new ( new FhMethodLocation("FFX.exe", 0x4E0BA0) );
    private byte*  p_toMenuNamePltNextH      => FhUtil.ptr_at<byte >(0x021D1670);
    private byte*  p_toMenuComPltNextH       => FhUtil.ptr_at<byte >(0x021D1640);
    private short* p_DAT_01871638            => FhUtil.ptr_at<short>(0x01471638);
    private byte*  p_DAT_00c56870            => FhUtil.ptr_at<byte >(0x00856870);
    private byte*  p_INT_0187150c            => FhUtil.ptr_at<byte >(0x0147150C);
    private int    TkMenuMainExchangePlayer1 => FhUtil.get_at<int  >(0x0147151C);
    private int    TkMenuMainExchangePlayer2 => FhUtil.get_at<int  >(0x01471520);


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_008c0220(uint param_1, float param_2, float param_3, float param_4, float param_5);
    private static FhMethodHandle<FUN_008c0220> _FUN_008c0220
        => new ( new FhMethodLocation("FFX.exe", 0x4C0220) );
    private int TkFont_a => FhUtil.get_at<int>(0x01FCC470);
    private int TkFont_b => FhUtil.get_at<int>(0x01FCC468);
    private int TkFont_g => FhUtil.get_at<int>(0x01FCC460);
    private int TkFont_r => FhUtil.get_at<int>(0x01FCC458);


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_008bc300(int param_1);
    private static FhMethodHandle<FUN_008bc300> _FUN_008bc300
        => new ( new FhMethodLocation("FFX.exe", 0x4BC300) );
    private        int*  p_DAT_01869ee4 => FhUtil.ptr_at<int >(0x01469EE4);
    private        int*  p_DAT_01869ee0 => FhUtil.ptr_at<int >(0x01469EE0);
    private        byte* p_DAT_01869eea => FhUtil.ptr_at<byte>(0x01469EEA);
    private static byte* textString;


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_008e67f0(uint gear_idx, float x, float y, byte color_id);
    private static FhMethodHandle<FUN_008e67f0> _FUN_008e67f0
        => new ( new FhMethodLocation("FFX.exe", 0x4E67F0) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DrawCrossMenuIconWeaponName2(void* param_1, float x, float y, byte color_id);
    private static FhMethodHandle<DrawCrossMenuIconWeaponName2> _DrawCrossMenuIconWeaponName2
        => new ( new FhMethodLocation("FFX.exe", 0x4E6970) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TOBtlDrawCommandWindow(void* param_1);
    private static FhMethodHandle<TOBtlDrawCommandWindow> _TOBtlDrawCommandWindow
        => new ( new FhMethodLocation("FFX.exe", 0x49F300) );
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void updateMenu(IntPtr menu);


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_008d85f0(void* param_1, int param_2);
    private static FhMethodHandle<FUN_008d85f0> _FUN_008d85f0
        => new ( new FhMethodLocation("FFX.exe", 0x4D85F0) );
    private uint DAT_0186ab60   => FhUtil.get_at<uint>(0x0146AB60);
    private int* p_DAT_0186aadc => FhUtil.ptr_at<int >(0x0146AADC);
    private int* p_DAT_0186ab68 => FhUtil.ptr_at<int >(0x0146AB68);
    private TkMenuItemData* p_TkMenuItemData_ARRAY_01597730 => FhUtil.ptr_at<TkMenuItemData>(0x01197730);
    [StructLayout(LayoutKind.Sequential)]
    public struct TkMenuItemData {
        public ushort item_id;
        public byte count;
        public byte field2_0x3;
    }



    // Pause Menu
    void h_TkMenuDrawMain(void* menu) {
        byte bVar1;
        int iVar2;
        int iVar3;
        uint uVar4;
        byte* pbVar5;
        float fVar7;
        float fVar8;
        float fVar9;
        float fVar10;
        float fVar11;
        float fVar12;
        float fVar13;
        float fVar14;
        float uVar14;
        float fVar15;
        float uVar16;
        float uVar17;
        float fVar18;
        float* pfVar19;
        float fVar20;
        byte* puVar21;
        uint uVar22;
        uint color_end;
        float local_54;
        float local_50;
        float local_4c;
        float local_48;
        float local_44;
        float local_40;
        float local_3c;
        float local_38;
        double local_34;
        float local_2c;
        float local_28;
        float local_24;
        double local_20;
        byte[] local_18 = new byte[16];
        byte[] HP;
        byte[] MP;

        local_38 = 0.0f;
        local_40 = 0.0f;
        local_3c = 0.0f;
        local_44 = 0.0f;
        local_48 = 0.0f;
        local_4c = 0.0f;
        local_50 = 0.0f;
        iVar2 = (int)FhXCall.TkMenuGetPlayerListMax2.fnptr!();
        FhXCall.TkVU1SyncPath.fnptr!();
        FhXCall.TOMenuOpenPktBuffTmp.fnptr!();
        fVar7 = FhXCall.graphicUiRemapX2.fnptr!(145.0f);
        FhXCall.TODrawMenuBG.fnptr!();
        *p_toMenuNamePltNextH = 0x2c;
        *p_toMenuComPltNextH = 0x20;
        local_24 = 0.0f;
        if (0 < iVar2) {
            do {
                fVar13 = local_24;
                local_2c = p_DAT_01871638[(int)local_24];
                if (local_2c != 0.0) {
                    iVar3 = (int)local_2c;
                    uVar4 = (uint)FhGCall.FUN_0088E6C0_0074C2B0.fnptr!(iVar3);
                    local_2c = (uVar4 & 0xffff) * -512.0f * 2.0f / 12288.0f;
                    uVar4 = FhXCall.TkMenuGetPlayerFromIndex2.fnptr!((int)fVar13);
                    local_24 = (int)local_24;
                    fVar8 = FhXCall.graphicUiRemapY2.fnptr!(80.0f); // Spacing between each character (originally 90.0f)
                    local_34 = (double)(fVar8 * local_24);
                    local_28 = FhXCall.graphicUiRemapY2.fnptr!(200.0f);
                    local_28 = local_28 + (float)local_34;
                    local_34 = (double)(local_2c + fVar7);
                    if (local_24 >= 7) { // Characters >= 7 use one of the 3 extra background plates in menu_new
                        fVar11 = local_24 * 86.0f + 170.0f;
                        fVar8 = local_24 * 86.0f + 98.0f;
                    }
                    else {
                        fVar11 = local_24 * 86.0f + 72.0f;
                        fVar8 = local_24 * 86.0f + 0.0f;
                    }
                    fVar20 = 1109.0f;
                    fVar15 = 0.0f;
                    local_24 = fVar8;
                    fVar9 = FhXCall.graphicUiRemapY2.fnptr!(72.0f);
                    fVar10 = FhXCall.graphicUiRemapX2.fnptr!(1109.0f);
                    fVar12 = local_28;
                    local_24 = FhXCall.graphicUiRemapX2.fnptr!(0.0f);
                    local_24 = local_24 + (float)local_34;
                    FhXCall.TOMkpShapeXYWHUV.fnptr!(-3, local_24, fVar12, fVar10, fVar9, fVar15, fVar8, fVar20, fVar11);
                    iVar3 = (int)FhXCall.FUN_008a9b20.fnptr!();
                    if ((int)fVar13 < iVar3) { // Draw animated texture for frontline members
                        uVar22 = 0x1ac56870;
                        puVar21 = p_DAT_00c56870;
                        fVar8 = fVar13 + 1 * 64.0f;
                        local_24 = (float)local_34;
                        uVar17 = -20.0f;
                        uVar16 = 50.0f;
                        fVar10 = 64.0f;
                        fVar9 = 250.0f;
                        uVar14 = 0;
                        local_2c = fVar8;
                        fVar11 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
                        fVar12 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
                        FhXCall.DrawWaterWaveShapeC2.fnptr!(local_24, local_28, fVar12, fVar11, uVar14, fVar8, fVar9, fVar10, uVar16, uVar17, (uint)puVar21, uVar22);
                        puVar21 = p_DAT_00c56870;
                        uVar22 = 0x1ac56870;
                        uVar17 = -20.0f; ;
                        uVar16 = 50.0f;
                        fVar20 = 64.0f;
                        fVar15 = 250.0f;
                        uVar14 = 250.0f;
                        fVar11 = local_2c;
                        fVar12 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
                        fVar9 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
                        fVar8 = local_28;
                        fVar10 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
                        FhXCall.DrawWaterWaveShapeC2.fnptr!(fVar10 + (float)local_34, fVar8, fVar9, fVar12, uVar14, fVar11, fVar15, fVar20, uVar16, uVar17, uVar22, (uint)puVar21);
                        uVar22 = 0x33c56870;
                        puVar21 = p_DAT_00c56870;
                        uVar17 = -10.0f;
                        uVar16 = -80.0f;
                        fVar10 = 64.0f;
                        fVar9 = 250.0f;
                        uVar14 = 300.0f;
                        fVar8 = local_2c;
                        fVar11 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
                        fVar12 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
                        FhXCall.DrawWaterWaveShapeC2.fnptr!(local_24, local_28, fVar12, fVar11, uVar14, fVar8, fVar9, fVar10, uVar16, uVar17, (uint)puVar21, uVar22);
                        puVar21 = p_DAT_00c56870;
                        uVar22 = 0x33c56870;
                        uVar17 = -10.0f;
                        uVar16 = -80.0f;
                        fVar20 = 64.0f;
                        fVar15 = 250.0f;
                        uVar14 = 550.0f;
                        fVar11 = local_2c;
                        fVar12 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
                        fVar9 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
                        fVar8 = local_28;
                        fVar10 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
                        FhXCall.DrawWaterWaveShapeC2.fnptr!(fVar10 + (float)local_34, fVar8, fVar9, fVar12, uVar14, fVar11, fVar15, fVar20, uVar16, uVar17, uVar22, (uint)puVar21);
                    }
                    uVar14 = 1.0f;
                    fVar12 = 0.82f;
                    bVar1 = FhXCall.FUN_008a9a20.fnptr!((int)uVar4);
                    fVar8 = FhXCall.graphicUiRemapY2.fnptr!(9.0f);
                    fVar8 = fVar8 + local_28;
                    fVar11 = FhXCall.graphicUiRemapX2.fnptr!(160.0f);
                    fVar11 = fVar11 + (float)local_34;
                    pbVar5 = FhXCall.TOGetSaveChrName.fnptr!((int)uVar4);
                    FhXCall.ToMakeBtlEasyEdgeFont.fnptr!(pbVar5, fVar11, fVar8, bVar1, fVar12, uVar14);
                    fVar8 = (local_40 + 41.0f) * 0.0009765625f;
                    fVar11 = (local_38 + 436.0f) * 0.0009765625f;
                    fVar18 = 0.0146484375f;
                    fVar20 = 0.34765625f;
                    fVar9 = FhXCall.graphicUiRemapY2.fnptr!(local_40 + 23.0f);
                    fVar10 = FhXCall.graphicUiRemapX2.fnptr!(local_38 + 61.5f);
                    fVar12 = FhXCall.graphicUiRemapY2.fnptr!(5.0f);
                    fVar12 = fVar12 + local_28;
                    fVar15 = FhXCall.graphicUiRemapX2.fnptr!(490.0f);
                    FhXCall.TOMkpShapeXYWHUV.fnptr!(0x21, fVar15 + (float)local_34, fVar12, fVar10, fVar9, fVar20, fVar18, fVar11, fVar8);
                    uVar14 = FhXCall.TkMenuGetMaxHP.fnptr!((int)uVar4);
                    uVar16 = FhXCall.TkMenuGetHP.fnptr!((int)uVar4);
                    HP = Encoding.UTF8.GetBytes($"{uVar16,5}/{uVar14,5}");
                    fVar9 = 0.0f;
                    fVar12 = 0.72f;
                    bVar1 = 0x25;
                    fVar8 = FhXCall.graphicUiRemapY2.fnptr!(6.0f);
                    fVar8 = fVar8 + local_28;
                    fVar11 = FhXCall.graphicUiRemapX2.fnptr!(604.0f);
                    fVar11 = fVar11 + (float)local_34 + local_3c;
                    fixed (byte* HPDisplay = HP) FhXCall.TOMkpCrossEasyStrFontSClut.fnptr!(HPDisplay, fVar11, fVar8, bVar1, fVar12, fVar9);
                    fVar18 = 0.040039063f;
                    fVar8 = (local_38 + 570.0f) * 0.0009765625f;
                    fVar20 = 0.0146484375f;
                    fVar15 = 0.49804688f;
                    fVar12 = FhXCall.graphicUiRemapY2.fnptr!(23.0f);
                    fVar9 = FhXCall.graphicUiRemapX2.fnptr!(local_38 + 49.0f);
                    fVar11 = FhXCall.graphicUiRemapY2.fnptr!(32.0f);
                    fVar11 = fVar11 + local_28;
                    fVar10 = FhXCall.graphicUiRemapX2.fnptr!(540.0f);
                    FhXCall.TOMkpShapeXYWHUV.fnptr!(0x22, fVar10 + (float)local_34, fVar11, fVar9, fVar12, fVar15, fVar20, fVar8, fVar18);
                    uVar14 = FhXCall.TkMenuGetMaxMP.fnptr!((int)uVar4);
                    uVar16 = FhXCall.TkMenuGetMP.fnptr!((int)uVar4);
                    MP = Encoding.UTF8.GetBytes($"{uVar16,4}/{uVar14,4}");
                    fVar9 = 0.0f;
                    fVar12 = 0.72f;
                    bVar1 = 0x25;
                    fVar8 = FhXCall.graphicUiRemapY2.fnptr!(34.0f);
                    fVar8 = fVar8 + local_28;
                    fVar11 = FhXCall.graphicUiRemapX2.fnptr!(625.0f);
                    fVar11 = fVar11 + (float)local_34 + local_3c;
                    fixed (byte* MPDisplay = MP) FhXCall.TOMkpCrossEasyStrFontSClut.fnptr!(MPDisplay, fVar11, fVar8, bVar1, fVar12, fVar9);
                    fVar18 = 636.0f;
                    fVar20 = 208.0f;
                    fVar15 = 603.0f;
                    fVar10 = 0.0f;
                    fVar11 = FhXCall.graphicUiRemapY2.fnptr!(33.0f);
                    fVar12 = FhXCall.graphicUiRemapX2.fnptr!(208.0f);
                    fVar8 = FhXCall.graphicUiRemapY2.fnptr!(28.0f);
                    fVar8 = fVar8 + local_28;
                    fVar9 = FhXCall.graphicUiRemapX2.fnptr!(844.0f);
                    FhXCall.TOMkpShapeXYWHUV.fnptr!(-1, fVar9 + (float)local_34, fVar8, fVar12, fVar11, fVar10, fVar15, fVar20, fVar18);
                    fVar18 = 0.6621094f;
                    fVar20 = 0.5595703f;
                    fVar15 = 0.5888672f;
                    fVar10 = 0.48632813f;
                    fVar11 = FhXCall.graphicUiRemapY2.fnptr!(75.0f);
                    fVar12 = FhXCall.graphicUiRemapX2.fnptr!(75.0f);
                    local_20 = (double)local_28;
                    fVar8 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                    fVar8 = (float)local_20 - fVar8;
                    fVar9 = FhXCall.graphicUiRemapX2.fnptr!(1038.0f);
                    FhXCall.TOMkpShapeXYWHUV.fnptr!(0x3d, fVar9 + (float)local_34, fVar8, fVar12, fVar11, fVar10, fVar15, fVar20, fVar18);
                    fVar18 = 0.11328125f;
                    fVar8 = (local_48 + 978.0f) * 0.0009765625f;
                    fVar20 = 0.08203125f;
                    fVar11 = (local_44 + 834.0f) * 0.0009765625f;
                    fVar9 = FhXCall.graphicUiRemapY2.fnptr!(26.0f);
                    fVar10 = FhXCall.graphicUiRemapX2.fnptr!(local_50 + 117.0f);
                    fVar12 = FhXCall.graphicUiRemapY2.fnptr!(35.0f);
                    fVar12 = fVar12 + local_28;
                    fVar15 = FhXCall.graphicUiRemapX2.fnptr!(local_4c + 952.0f);
                    FhXCall.TOMkpShapeXYWHUV.fnptr!(0x3d, fVar15 + (float)local_34, fVar12, fVar10, fVar9, fVar11, fVar20, fVar8, fVar18);
                    pfVar19 = &local_54;
                    iVar3 = (int)FhXCall.FUN_008a9b30.fnptr!((byte)uVar4);
                    FhXCall.FUN_00905230.fnptr!(iVar3, pfVar19, 0.7f, 0.0f);
                    uVar14 = 1.0f;
                    fVar12 = 0.68f;
                    bVar1 = 0;
                    fVar8 = FhXCall.graphicUiRemapY2.fnptr!(16.0f);
                    fVar8 = fVar8 + local_28;
                    fVar11 = FhXCall.graphicUiRemapX2.fnptr!(1076.0f);
                    fVar11 = fVar11 + (float)local_34 - local_54 * 0.5f;
                    iVar3 = (int)FhXCall.FUN_008a9b30.fnptr!((byte)uVar4);
                    FhXCall.FUN_00905820.fnptr!(iVar3, fVar11, fVar8, bVar1, fVar12, uVar14);
                    if (*p_INT_0187150c == uVar4) {
                        fVar12 = 0.0f;
                        fVar8 = FhXCall.graphicUiRemapY2.fnptr!(14.0f);
                        fVar8 = fVar8 + local_28;
                        fVar11 = FhXCall.graphicUiRemapX2.fnptr!(150.0f);
                        FhXCall.TkMn2DrawCrossCursor.fnptr!(fVar11 + (float)local_34, fVar8, (int)fVar12);
                    }
                    if ((-1 < TkMenuMainExchangePlayer1) && (FhXCall.TkMenuGetPlayerFromIndex2.fnptr!(TkMenuMainExchangePlayer1) == uVar4)) {
                        if (TkMenuMainExchangePlayer2 < 0) {
                            fVar12 = 0.0f;
                            fVar8 = FhXCall.graphicUiRemapY2.fnptr!(14.0f);
                            fVar8 = fVar8 + local_28;
                            fVar11 = FhXCall.graphicUiRemapX2.fnptr!(150.0f);
                            FhXCall.TkMn2DrawCrossCursor.fnptr!(fVar11 + (float)local_34, fVar8, (int)fVar12);
                        }
                        else {
                            iVar3 = (int)FhXCall.FUN_008a9c10.fnptr!();
                            if ((iVar3 / 2 & 1U) != 0) {
                                iVar3 = 0;
                                fVar8 = FhXCall.graphicUiRemapY2.fnptr!(9.0f);
                                fVar8 = fVar8 + local_28;
                                fVar11 = FhXCall.graphicUiRemapX2.fnptr!(140.0f);
                                FhXCall.FUN_008c13b0.fnptr!(fVar11 + (float)local_34, fVar8, iVar3);
                            }
                        }
                    }
                    if ((-1 < TkMenuMainExchangePlayer2) && (FhXCall.TkMenuGetPlayerFromIndex2.fnptr!(TkMenuMainExchangePlayer2) == uVar4)) {
                        fVar12 = 0.0f;
                        fVar8 = FhXCall.graphicUiRemapY2.fnptr!(14.0f);
                        fVar8 = fVar8 + local_28;
                        fVar11 = FhXCall.graphicUiRemapX2.fnptr!(150.0f);
                        FhXCall.TkMn2DrawCrossCursor.fnptr!(fVar11 + (float)local_34, fVar8, (int)fVar12);
                    }
                }
                local_24 = (int)fVar13 + 1;
            } while ((int)local_24 < iVar2);
        }
        uVar22 = 0x40ffffff;
        uVar4 = 0xffffff;
        fVar13 = FhXCall.graphicUiRemapY2.fnptr!(32.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(600.0f);
        fVar11 = FhXCall.graphicUiRemapY2.fnptr!(870.0f);
        fVar12 = FhXCall.graphicUiRemapX2.fnptr!(639.0f);
        FhXCall.TODrawCrossBoxXYWHC2.fnptr!(fVar12, fVar11, fVar8, fVar13, uVar4, uVar22);
        iVar2 = FhXCall.MsGetGIL.fnptr!();
        fVar13 = FhXCall.graphicUiRemapY2.fnptr!(32.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(1108.0f);
        fVar11 = FhXCall.graphicUiRemapY2.fnptr!(870.0f);
        fVar12 = FhXCall.graphicUiRemapX2.fnptr!(145.0f);
        FhXCall.FUN_008c09f0.fnptr!(fVar12, fVar11, fVar8, fVar13, iVar2);
        uVar4 = (uint)FhXCall.FUN_008a9c00.fnptr!();
        color_end = 0xffffff;
        uVar22 = 0x40ffffff;
        iVar2 = ((uVar4 & 1) != 0) ? 37 : 1;
        fVar13 = FhXCall.graphicUiRemapY2.fnptr!(32.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(325.0f);
        fVar11 = FhXCall.graphicUiRemapY2.fnptr!(870.0f);
        fVar12 = FhXCall.graphicUiRemapX2.fnptr!(145.0f);
        FhXCall.TODrawCrossBoxXYWHC2.fnptr!(fVar12, fVar11, fVar8, fVar13, uVar22, color_end);
        bVar1 = 0x25;
        fVar13 = FhXCall.graphicUiRemapY2.fnptr!(878.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(270.0f);
        FhXCall.FUN_008e19f0.fnptr!(uVar4, fVar8, fVar13, bVar1, iVar2);
        fVar20 = 599.0f;
        fVar15 = 1600.0f;
        fVar10 = 544.0f;
        fVar9 = 0.0f;
        fVar13 = FhXCall.graphicUiRemapY2.fnptr!(55.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(1130.0f);
        fVar11 = FhXCall.graphicUiRemapY2.fnptr!(951.0f);
        fVar12 = FhXCall.graphicUiRemapX2.fnptr!(145.0f);
        FhXCall.TOMkpShapeXYWHUVC2.fnptr!(0xffffffff, fVar12, fVar11, fVar8, fVar13, fVar9, fVar10, fVar15, fVar20, 0x80808080, 0x00808080);
        fVar10 = 0.49316406f;
        fVar9 = 0.8808594f;
        fVar12 = 0.4658203f;
        fVar11 = 0.5292969f;
        fVar13 = FhXCall.graphicUiRemapY2.fnptr!(28.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(360.0f);
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(933.0f);
        fVar14 = FhXCall.graphicUiRemapX2.fnptr!(145.0f);
        FhXCall.TOMkpShapeXYWHUV.fnptr!(200, fVar14, fVar7, fVar8, fVar13, fVar11, fVar12, fVar9, fVar10);
        uVar4 = FhGCall.AtelGetSaveDic.fnptr!();
        iVar2 = FhXCall.MsGetSaveConfigEnglish.fnptr!();
        pbVar5 = FhGCall.AtelGetSaveDicName.fnptr!((ushort)uVar4, (uint)iVar2);
        FhXCall.TkMenuDraw1612Width.fnptr!(pbVar5);
        fVar12 = 1.0f;
        fVar11 = 0.78f;
        bVar1 = 0;
        fVar13 = FhXCall.graphicUiRemapY2.fnptr!(956.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(235.0f);
        FhXCall.TOMkpCrossExtMesFontLClut.fnptr!(0, pbVar5, fVar8, fVar13, bVar1, fVar11, fVar12);
        FhXCall.TOMenuDrawKickTmp.fnptr!();
        FhXCall.TkVU1SyncPath.fnptr!();
        return;
    }

    // Character Portraits
    void h_FUN_008c0220(uint param_1, float param_2, float param_3, float param_4, float param_5) {
        float fVar1;
        float fVar2;
        float fVar3;
        float fVar4;
        int iVar5;
        byte* pcVar6;
        byte* tex_path;
        uint uVar7;
        float local_b0;
        float local_ac;
        float local_a8;
        byte* local_a4;
        graphicDrawUIAbmapElement_param1 local_a0 = new();
        float v;

        fVar4 = TkFont_a;
        fVar3 = TkFont_b;
        fVar2 = TkFont_g;
        fVar1 = TkFont_r;
        if (param_1 < 8) {
            local_a4 = FhXCall.TOGetShapTextureName.fnptr!(0x2ed0); // face_ply
            FhXCall.TOGetImageWH.fnptr!(0x2ed0, &local_ac, &local_b0);
            if (param_1 == 7) { // Seymour
                param_1 = 8;
                uVar7 = 4;
                pcVar6 = (byte*)100;
                local_a0.floats0[0] = param_2;
                local_a0.floats0[1] = param_3;
                local_a0.floats0[2] = uVar7 * 100 / local_ac;
                local_a0.floats0[3] = (int)pcVar6 / local_b0;
                local_a0.ints0[0] = (int)fVar4; local_a0.ints0[1] = (int)fVar3;
                local_a0.ints0[2] = (int)fVar2; local_a0.ints0[3] = (int)fVar1;
                local_a0.floats1[0] = param_4 + param_2;
                local_a0.floats1[1] = param_5 + param_3;
                local_a0.floats1[2] = (uVar7 * 100 + 100) / local_ac;
                local_a0.floats1[3] = ((int)pcVar6 + 100) / local_b0;
                local_a0.ints1[0] = (int)fVar4; local_a0.ints1[1] = (int)fVar3;
                local_a0.ints1[2] = (int)fVar2; local_a0.ints1[3] = (int)fVar1;
                _graphicDrawUIElement.fnptr!(&local_a0, local_a4, 1, 0, 0);
                return;
            }
            else {
                if (param_1 == 6)
                {
                    iVar5 = FhXCall.AtelGetAlbhedRikku.fnptr!();
                    if (iVar5 == 1) param_1 = 7;
                }
                uVar7 = param_1 & 0x80000003;
                if ((int)uVar7 < 0)
                {
                    uVar7 = (uVar7 - 1 | 0xfffffffc) + 1;
                }
            }
            local_a0.floats0[0] = param_2;
            local_a0.floats0[1] = param_3;
            local_a0.floats0[2] = (int)(uVar7 * 100) / local_ac;
            pcVar6 = (byte*)(((int)param_1 >> 2) * 100);
            local_a0.floats0[3] = (int)pcVar6 / local_b0;
            local_a0.ints0[0] = (int)fVar4;
            local_a0.ints0[1] = (int)fVar3;
            local_a0.ints0[2] = (int)fVar2;
            local_a0.ints0[3] = (int)fVar1;
            local_a0.floats1[0] = param_4 + param_2;
            local_a0.floats1[1] = param_3 + param_5;
            local_a0.floats1[2] = (int)(uVar7 * 100 + 100) / local_ac;
            local_a8 = (int)(pcVar6 + 100);
            local_a0.floats1[3] = local_a8 / local_b0;
            local_a0.ints1[0] = (int)fVar4;
            local_a0.ints1[1] = (int)fVar3;
            local_a0.ints1[2] = (int)fVar2;
            local_a0.ints1[3] = (int)fVar1;
            _graphicDrawUIElement.fnptr!(&local_a0, local_a4, 1, 0, 0);
            return;
        }
        pcVar6 = FhXCall.TOGetShapTextureName.fnptr!(0x2ed4); // face_sum
        FhXCall.TOGetImageWH.fnptr!(0x2ed4, &local_ac, &local_b0);
        local_a0.floats0[0] = param_2;
        local_a0.floats0[1] = param_3;
        tex_path = (byte*)((int)(param_1 - 8) / 5 * 100);
        iVar5 = (int)(param_1 - 8) % 5 * 100;
        local_a0.floats0[2] = iVar5 / local_ac;
        local_a0.floats0[3] = (int)tex_path / local_b0;
        local_a0.ints0[0] = (int)fVar4;
        local_a0.ints0[1] = (int)fVar3;
        local_a0.ints0[2] = (int)fVar2;
        local_a0.ints0[3] = (int)fVar1;
        local_a0.floats1[0] = param_4 + param_2;
        local_a0.floats1[1] = param_3 + param_5;
        local_a0.floats1[2] = (iVar5 + 100) / local_ac;
        v = (int)tex_path + 100;
        local_a0.floats1[3] = v / local_b0;
        local_a0.ints1[0] = (int)fVar4;
        local_a0.ints1[1] = (int)fVar3;
        local_a0.ints1[2] = (int)fVar2;
        local_a0.ints1[3] = (int)fVar1;
        _graphicDrawUIElement.fnptr!(&local_a0, pcVar6, 1, 0, 0);
        return;
    }

    // Battle Results: AP Earned
    void h_FUN_008bc300(int param_1) {
        byte* name;
        int iVar2;
        int iVar3;
        float fVar4;
        float fVar5;
        float fVar6;
        float fVar7;
        float uVar8;
        float fVar9;
        float fVar10;
        float fVar11;
        float uVar12;
        byte bVar13;
        float uVar14;
        float* pfVar15;
        float fVar16;
        byte* puVar17;
        uint uVar18;
        float local_2c;
        double local_28;
        float local_20;
        float local_1c;
        float local_18;
        float local_14;
        float local_10;
        float local_c;
        float local_8;

        local_20 = 0.0f;
        local_14 = 0.0f;
        local_10 = 0.0f;
        local_1c = 0.0f;
        local_18 = 0.0f;
        local_c = 0.0f;
        switch (*(short*)((int)p_DAT_01869ee4 + param_1 * 0xe)) {
            case 0:
            case 5:
                goto switchD_008bc339_caseD_0;
            case 1:
                uVar18 = (uint)FhGCall.FUN_0088E6C0_0074C2B0.fnptr!(*(short*)((int)p_DAT_01869ee0 + param_1 * 0xe + 2));
                iVar2 = (int)((uVar18 & 0xffff) * -0x200);
                goto LAB_008bc382;
            case 2:
            case 3:
                local_c = 0.0f;
                break;
            case 4:
                uVar18 = (uint)FhGCall.FUN_0088E6A0_0074C290.fnptr!(0x1000 - *(short*)((int)p_DAT_01869ee0 + param_1 * 0xe + 2));
                iVar2 = (int)(((uVar18 & 0xffff) - 0x1000) * 0x200);
            LAB_008bc382:
                local_c = (int)(iVar2 + (iVar2 >> 0x1f & 0xfffU)) >> 0xc;
                break;
        }
        FhXCall.TOMenuOpenPktBuffTmp.fnptr!();
        fVar4 = FhXCall.graphicUiRemapX2.fnptr!(210.0f);
        local_c = fVar4 + local_c;
        local_8 = param_1 * 0x50 + 0x10c; // Spacing between each character (originally param_1 * 0x5a + 0x116)
        local_8 = FhXCall.graphicUiRemapY2.fnptr!(local_8);
        if (param_1 >= 7) { // Characters >= 7 use one of the 3 extra background plates in menu_new
            fVar4 = param_1 * 86.0f + 170.0f;
            fVar7 = param_1 * 86.0f + 98.0f;
        }
        else {
            fVar4 = param_1 * 86.0f + 72.0f;
            fVar7 = param_1 * 86.0f + 0.0f;
        }
        fVar16 = 1110.0f;
        fVar11 = 0.0f;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(72.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(1110.0f);
        FhXCall.TOMkpShapeXYWHUV.fnptr!(-3, local_c, local_8, fVar6, fVar5, fVar11, fVar7, fVar16, fVar4);
        uVar18 = 0x1ac56870;
        puVar17 = p_DAT_00c56870;
        fVar4 = (param_1 + 1) * 64.0f;
        uVar14 = -20.0f;
        uVar12 = 50.0f;
        fVar16 = 64.0f;
        fVar11 = 250.0f;
        uVar8 = 0;
        fVar7 = fVar4;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
        FhXCall.DrawWaterWaveShapeC2.fnptr!(local_c, local_8, fVar6, fVar5, uVar8, fVar7, fVar11, fVar16, uVar12, uVar14, (uint)puVar17, uVar18);
        puVar17 = p_DAT_00c56870;
        uVar18 = 0x1ac56870;
        uVar14 = -20.0f;
        uVar12 = 50.0f;
        fVar10 = 64.0f;
        fVar9 = 250.0f;
        uVar8 = 250.0f;
        fVar5 = fVar4;
        fVar6 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
        fVar11 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
        fVar7 = local_8;
        fVar16 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
        local_28 = (double)(fVar16 + local_c);
        FhXCall.DrawWaterWaveShapeC2.fnptr!(fVar16 + local_c, fVar7, fVar11, fVar6, uVar8, fVar5, fVar9, fVar10, uVar12, uVar14, uVar18, (uint)puVar17);
        uVar18 = 0x33c56870;
        puVar17 = p_DAT_00c56870;
        uVar14 = -10.0f;
        uVar12 = -80.0f;
        fVar16 = 64.0f;
        fVar11 = 250.0f;
        uVar8 = 300.0f;
        fVar7 = fVar4;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
        FhXCall.DrawWaterWaveShapeC2.fnptr!(local_c, local_8, fVar6, fVar5, uVar8, fVar7, fVar11, fVar16, uVar12, uVar14, (uint)puVar17, uVar18);
        puVar17 = p_DAT_00c56870;
        uVar18 = 0x33c56870;
        uVar14 = -10.0f;
        uVar12 = -80.0f;
        fVar9 = 64.0f;
        fVar16 = 250.0f;
        uVar8 = 550.0f;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
        fVar7 = local_8;
        fVar11 = FhXCall.graphicUiRemapX2.fnptr!(250.0f);
        FhXCall.DrawWaterWaveShapeC2.fnptr!(fVar11 + local_c, fVar7, fVar6, fVar5, uVar8, fVar4, fVar16, fVar9, uVar12, uVar14, uVar18, (uint)puVar17);
        fVar10 = 688.0f;
        fVar9 = 1104.0f;
        fVar16 = 618.0f;
        fVar11 = 689.0f;
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(70.0f);
        fVar5 = FhXCall.graphicUiRemapX2.fnptr!(415.0f);
        fVar4 = local_8;
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(1090.0f);
        FhXCall.TOMkpShapeXYWHUV.fnptr!(-3, fVar6 + local_c, fVar4, fVar5, fVar7, fVar11, fVar16, fVar9, fVar10);
        uVar8 = 1.0f;
        fVar5 = 0.82f;
        bVar13 = 0;
        fVar4 = FhXCall.graphicUiRemapY2.fnptr!(9.0f);
        fVar4 = fVar4 + local_8;
        fVar7 = FhXCall.graphicUiRemapX2.fnptr!(160.0f);
        fVar7 = fVar7 + local_c;
        name = FhXCall.TOGetSaveChrName.fnptr!(*(short*)((int)p_DAT_01869ee4 + param_1 * 0xe + 2));
        FhXCall.ToMakeBtlEasyEdgeFont.fnptr!(name, fVar7, fVar4, bVar13, fVar5, uVar8);
        fVar10 = 0.10253906f;
        fVar4 = (local_10 + 434.0f) * 0.0009765625f;
        fVar9 = 0.07519531f;
        fVar16 = 0.37304688f;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(28.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(local_10 + 55.0f);
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(33.0f);
        fVar7 = fVar7 + local_8;
        fVar11 = FhXCall.graphicUiRemapX2.fnptr!(local_20 + 758.0f);
        FhXCall.TOMkpShapeXYWHUV.fnptr!(200, fVar11 + local_c, fVar7, fVar6, fVar5, fVar16, fVar9, fVar4, fVar10);
        uVar12 = 0;
        fVar6 = 0.7f;
        uVar8 = 0x25;
        fVar4 = FhXCall.graphicUiRemapY2.fnptr!(27.0f);
        fVar4 = fVar4 + local_8;
        fVar7 = FhXCall.graphicUiRemapX2.fnptr!(local_20 + 748.0f);
        fVar7 = fVar7 + local_c;
        fVar5 = FhXCall.FUN_008bd9d0.fnptr!(*(short*)((int)p_DAT_01869ee4 + param_1 * 0xe + 2));
        FhXCall.ToMakeBtlEasyDigitRight.fnptr!((int)fVar5, fVar7, fVar4, (int)uVar8, fVar6, uVar12);
        fVar10 = 0.15234375f;
        fVar9 = 0.7421875f;
        fVar16 = 0.12402344f;
        fVar11 = 0.3671875f;
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(28.0f);
        fVar5 = FhXCall.graphicUiRemapX2.fnptr!(384.0f);
        fVar4 = FhXCall.graphicUiRemapY2.fnptr!(2.0f);
        fVar4 = fVar4 + local_8;
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(1096.0f);
        FhXCall.TOMkpShapeXYWHUV.fnptr!(200, fVar6 + local_c, fVar4, fVar5, fVar7, fVar11, fVar16, fVar9, fVar10);
        fVar10 = 636.0f;
        fVar9 = 208.0f;
        fVar16 = 603.0f;
        fVar11 = 0.0f;
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(33.0f);
        fVar5 = FhXCall.graphicUiRemapX2.fnptr!(208.0f);
        fVar4 = FhXCall.graphicUiRemapY2.fnptr!(29.0f);
        fVar4 = fVar4 + local_8;
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(844.0f);
        FhXCall.TOMkpShapeXYWHUV.fnptr!(-1, fVar6 + local_c, fVar4, fVar5, fVar7, fVar11, fVar16, fVar9, fVar10);
        fVar10 = 0.6621094f;
        fVar9 = 0.5595703f;
        fVar16 = 0.5888672f;
        fVar11 = 0.48632813f;
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(75.0f);
        fVar5 = FhXCall.graphicUiRemapX2.fnptr!(75.0f);
        local_28 = local_8;
        fVar4 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
        fVar4 = (float)local_28 - fVar4;
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(1038.0f);
        FhXCall.TOMkpShapeXYWHUV.fnptr!(0x3d, fVar6 + local_c, fVar4, fVar5, fVar7, fVar11, fVar16, fVar9, fVar10);
        fVar10 = 0.11328125f;
        fVar4 = (local_10 + 978.0f) * 0.0009765625f;
        fVar9 = 0.08203125f;
        fVar7 = (local_14 + 834.0f) * 0.0009765625f;
        fVar6 = FhXCall.graphicUiRemapY2.fnptr!(32.0f);
        fVar11 = FhXCall.graphicUiRemapX2.fnptr!(local_18 + 144.0f);
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(32.0f);
        fVar5 = fVar5 + local_8;
        fVar16 = FhXCall.graphicUiRemapX2.fnptr!(local_1c + 935.0f);
        FhXCall.TOMkpShapeXYWHUV.fnptr!(0x3d, fVar16 + local_c, fVar5, fVar11, fVar6, fVar7, fVar9, fVar4, fVar10);
        pfVar15 = &local_2c;
        iVar2 = (int)FhXCall.FUN_008a9b30.fnptr!((byte)*(ushort*)((int)p_DAT_01869ee4 + param_1 * 0xe + 2));
        FhXCall.FUN_00905230.fnptr!(iVar2, pfVar15, 0.7f, 0.0f);
        fVar5 = 0.7f;
        bVar13 = 0;
        fVar4 = FhXCall.graphicUiRemapY2.fnptr!(16.0f);
        fVar4 = fVar4 + local_8;
        fVar7 = FhXCall.graphicUiRemapX2.fnptr!(1076.0f);
        fVar7 = fVar7 + local_c - local_2c * 0.5f;
        iVar2 = (int)FhXCall.FUN_008a9b30.fnptr!((byte)*(ushort*)((int)p_DAT_01869ee4 + param_1 * 0xe + 2));
        FhXCall.ToMakeBtlEasyDigit2.fnptr!(iVar2, fVar7, fVar4, bVar13, fVar5);
        fVar10 = 0.10253906f;
        fVar4 = (local_10 + 434.0f) * 0.0009765625f;
        fVar9 = 0.07519531f;
        fVar16 = 0.37304688f;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(28.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(local_10 + 55.0f);
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(34.0f);
        fVar7 = fVar7 + local_8;
        fVar11 = FhXCall.graphicUiRemapX2.fnptr!(1348.0f);
        FhXCall.TOMkpShapeXYWHUV.fnptr!(200, fVar11 + local_c, fVar7, fVar6, fVar5, fVar16, fVar9, fVar4, fVar10);
        iVar2 = FhXCall.FUN_008bda10.fnptr!((byte)*(ushort*)((int)p_DAT_01869ee4 + param_1 * 0xe + 2));
        fVar7 = 0.0f;
        fVar4 = 0.7f;
        uVar8 = 0x25;
        if (iVar2 < 99) {
            fVar5 = FhXCall.graphicUiRemapY2.fnptr!(28.0f);
            fVar5 = fVar5 + local_8;
            fVar6 = FhXCall.graphicUiRemapX2.fnptr!(1333.0f);
            fVar6 = fVar6 + local_c;
            iVar2 = FhXCall.MsGetNextAP.fnptr!(*(short*)((int)p_DAT_01869ee4 + param_1 * 0xe + 2));
            iVar3 = FhXCall.FUN_00785370.fnptr!((byte)*(short*)((int)p_DAT_01869ee4 + param_1 * 0xe + 2));
            FhXCall.ToMakeBtlEasyDigitRight.fnptr!(iVar2 - iVar3, fVar6, fVar5, (int)uVar8, fVar4, fVar7);
        }
        else {
            fVar5 = FhXCall.graphicUiRemapY2.fnptr!(38.0f);
            bVar13 = (byte)uVar8;
            fVar5 = fVar5 + local_8;
            fVar6 = FhXCall.graphicUiRemapX2.fnptr!(1210.0f);
            FhXCall.TOMkpCrossEasyStrFontSClut.fnptr!(textString, fVar6 + local_c, fVar5, bVar13, fVar4, fVar7);
        }
        if (0 < p_DAT_01869eea[param_1 * 0xe]) {
            uVar18 = (uint)(0xf - p_DAT_01869eea[param_1 * 0xe]);
            if ((int)uVar18 < 3) {
                uVar18 = (uVar18 < 0) ? 0 : uVar18;
            }
            else {
                uVar18 = 2;
            }
            iVar2 = 10;
            fVar5 = FhXCall.graphicUiRemapY2.fnptr!(54.0f);
            fVar4 = FhXCall.graphicUiRemapX2.fnptr!(100.0f);
            fVar4 = fVar4 * (int)(uVar18 + 1);
            fVar7 = FhXCall.graphicUiRemapY2.fnptr!(32.0f);
            fVar7 = fVar7 + local_8;
            fVar6 = FhXCall.graphicUiRemapX2.fnptr!(1110.0f);
            FhXCall.TODrawMenuPlateXYWHType.fnptr!(fVar6 + local_c, fVar7, fVar4, fVar5, iVar2);
            if (uVar18 == 2) {
                fVar10 = 0.11328125f;
                fVar4 = (local_10 + 978.0f) * 0.0009765625f;
                fVar9 = 0.08203125f;
                fVar7 = (local_14 + 834.0f) * 0.0009765625f;
                fVar6 = FhXCall.graphicUiRemapY2.fnptr!(32.0f);
                fVar11 = FhXCall.graphicUiRemapX2.fnptr!(local_18 + 144.0f);
                fVar5 = FhXCall.graphicUiRemapY2.fnptr!(43.0f);
                fVar5 = fVar5 + local_8;
                fVar16 = FhXCall.graphicUiRemapX2.fnptr!(local_1c + 1152.0f);
                FhXCall.TOMkpShapeXYWHUV.fnptr!(0x3d, fVar16 + local_c, fVar5, fVar11, fVar6, fVar7, fVar9, fVar4, fVar10);
                fVar10 = 0.6386719f;
                fVar4 = (local_10 + 680.0f) * 0.0009765625f;
                fVar9 = 0.6064453f;
                fVar7 = (local_14 + 614.0f) * 0.0009765625f;
                fVar6 = FhXCall.graphicUiRemapY2.fnptr!(33.0f);
                fVar11 = FhXCall.graphicUiRemapX2.fnptr!(local_18 + 66.0f);
                fVar5 = FhXCall.graphicUiRemapY2.fnptr!(43.0f);
                fVar5 = fVar5 + local_8;
                fVar16 = FhXCall.graphicUiRemapX2.fnptr!(local_1c + 1265.0f);
                FhXCall.TOMkpShapeXYWHUV.fnptr!(0x3d, fVar16 + local_c, fVar5, fVar11, fVar6, fVar7, fVar9, fVar4, fVar10);
            }
            p_DAT_01869eea[param_1 * 0xe] = (byte)(p_DAT_01869eea[param_1 * 0xe] + -1);
        }
        FhXCall.TOMenuDrawKickTmp.fnptr!();
    switchD_008bc339_caseD_0:
        return;
    }

    // Equipment Names + Icons for Swap/Discard, Equip & Customize Menus
    void h_FUN_008e67f0(uint gear_idx, float x, float y, byte color_id) {
        Equipment* pSVar1;
        byte* pbVar2;
        byte bVar3;
        float fVar4;
        float fVar5;
        float fVar6;
        float fVar7;
        byte bVar8;
        byte bVar9;
        byte bVar10;
        byte bVar11;
        byte* local_c;
        float local_8;

        pSVar1 = FhXCall.MsGetSaveWeapon.fnptr!(gear_idx, (nint)(&local_c));
        pbVar2 = FhXCall.MsGetSaveWeaponName.fnptr!(gear_idx);
        bVar11 = 0x80;
        if (pSVar1->owner == 7) {
            bVar3 = (byte)(37 * 2 + 2 + pSVar1->type);
        }
        else {
            bVar3 = (byte)(pSVar1->owner * 2 + 1 + pSVar1->type);
        }
        bVar10 = 0x80;
        bVar9 = 0x80;
        bVar8 = 0x80;
        fVar4 = FhXCall.graphicUiRemapY2.fnptr!(46.0f);
        fVar5 = FhXCall.graphicUiRemapX2.fnptr!(38.0f);
        fVar6 = FhXCall.graphicUiRemapY2.fnptr!(7.0f);
        fVar6 = fVar6 + y;
        local_8 = fVar6;
        local_8 = FhXCall.graphicUiRemapX2.fnptr!(180.0f);
        local_8 = local_8 + x;
        FhXCall.DrawCrossMenuIconXYWHRGBA.fnptr!(local_8, fVar6, fVar5, fVar4, bVar3, bVar8, bVar9, bVar10, bVar11);
        fVar4 = 0.78f;
        fVar6 = FhXCall.graphicUiRemapY2.fnptr!(8.0f);
        fVar6 = fVar6 + y;
        local_8 = fVar6;
        local_8 = FhXCall.graphicUiRemapX2.fnptr!(240.0f);
        local_8 = local_8 + x;
        FhXCall.ToMakeBtlEasyFont.fnptr!(pbVar2, local_8, fVar6, color_id, fVar4);
        if (pSVar1->owner == pSVar1->equipped_by) {
            bVar11 = 0x80;
            bVar10 = 0x80;
            bVar9 = 0x80;
            bVar8 = 0x80;
            bVar3 = 0x31;
            fVar4 = FhXCall.graphicUiRemapY2.fnptr!(46.0f);
            fVar5 = FhXCall.graphicUiRemapX2.fnptr!(38.0f);
            fVar6 = FhXCall.graphicUiRemapY2.fnptr!(7.0f);
            fVar6 = fVar6 + y;
            fVar7 = FhXCall.graphicUiRemapX2.fnptr!(180.0f);
            FhXCall.DrawCrossMenuIconXYWHRGBA.fnptr!(fVar7 + x, fVar6, fVar5, fVar4, bVar3, bVar8, bVar9, bVar10, bVar11);
        }
        return;
    }

    // Equipment Names + Icons for Shops & Inventory
    void h_DrawCrossMenuIconWeaponName2(void* param_1, float x, float y, byte color_id) {
        bool hiragana;
        byte* pbVar1;
        byte bVar2;
        float fVar3;
        float fVar4;
        float fVar5;
        float fVar6;
        ushort* ref_model_id;
        byte a;
        byte b;
        byte g;
        byte r;
        uint chr_id;

        ushort* param_1_00 = (ushort*)param_1;
        ref_model_id = (ushort*)0x0;
        hiragana = FhXCall.MsGetSaveConfigHiragana.fnptr!();
        pbVar1 = _MsWeaponName.fnptr!(*param_1_00, (byte)param_1_00[2], hiragana, ref_model_id);
        a = 0x80;
        chr_id = (byte)param_1_00[2];
        if (chr_id == 7) {
            chr_id = 37;
            bVar2 = (byte)((byte)chr_id * 2 + 2 + *(byte*)((int)param_1_00 + 5));
        }
        else {
            bVar2 = (byte)((byte)param_1_00[2] * 2 + 1 + *(byte*)((int)param_1_00 + 5));
        }
        b = 0x80;
        g = 0x80;
        r = 0x80;
        fVar3 = FhXCall.graphicUiRemapY2.fnptr!(46.0f);
        fVar4 = FhXCall.graphicUiRemapX2.fnptr!(38.0f);
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(7.0f);
        fVar5 = fVar5 + y;
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(180.0f);
        FhXCall.DrawCrossMenuIconXYWHRGBA.fnptr!(fVar6 + x, fVar5, fVar4, fVar3, bVar2, r, g, b, a);
        fVar4 = 0.78f;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(8.0f);
        fVar5 = fVar5 + y;
        fVar3 = FhXCall.graphicUiRemapX2.fnptr!(240.0f);
        FhXCall.ToMakeBtlEasyFont.fnptr!(pbVar1, fVar3 + x, fVar5, color_id, fVar4);
        if ((byte)param_1_00[2] == (byte)param_1_00[3]) {
            a = 0x80;
            b = 0x80;
            g = 0x80;
            r = 0x80;
            bVar2 = 0x31;
            fVar3 = FhXCall.graphicUiRemapY2.fnptr!(46.0f);
            fVar4 = FhXCall.graphicUiRemapX2.fnptr!(38.0f);
            fVar5 = FhXCall.graphicUiRemapY2.fnptr!(7.0f);
            fVar5 = fVar5 + y;
            fVar6 = FhXCall.graphicUiRemapX2.fnptr!(180.0f);
            FhXCall.DrawCrossMenuIconXYWHRGBA.fnptr!(fVar6 + x, fVar5, fVar4, fVar3, bVar2, r, g, b, a);
        }
        return;
    }

    // Equipment Names + Icons for Battle Menus
    int h_TOBtlDrawCommandWindow(void* param_1) {
        short sVar1;
        float fVar2;
        byte bVar3;
        uint RVar4;
        int iVar5;
        int iVar6;
        byte* pbVar7;
        uint uVar8;
        Equipment* pSVar9;
        int iVar10;
        int iVar11;
        double fVar12;
        float fVar13;
        float fVar14;
        float fVar15;
        float fVar16;
        float fVar17;
        float fVar18;
        float fVar19;
        float fVar20;
        float fVar21;
        float fVar22;
        byte bVar23;
        float fVar24;
        float uVar25;
        byte bVar26;
        float fVar27;
        float uVar28;
        byte bVar29;
        uint RVar30;
        int uVar31;
        byte bVar32;
        uint uVar33;
        int local_48;
        byte* local_2c;
        Command* local_28;
        float local_24;
        float local_20;
        float local_1c;
        float local_18;
        float local_14;
        float local_10;
        float local_c;
        float local_8;
        uint color;
        IntPtr func_addr;

        uint param_1_00 = (uint)param_1;
        local_c = 0.0f;
        fVar2 = param_1_00;
        fVar12 = 0;
        if (fVar12 < (double)*(float*)((int)param_1_00 + 0xdc)) {
            fVar12 = (double)FhXCall.graphicGetTime.fnptr!();
            fVar12 = fVar12 - (double)*(float*)((int)param_1_00 + 0xdc);
        }
        *(float*)((int)param_1_00 + 0xe0) = (float)fVar12;
        local_10 = *(float*)((int)param_1_00 + 0xe0);
        iVar11 = *(short*)((int)param_1_00 + 0x38);
        local_28 = (Command*)((*(int*)((int)param_1_00 + 0x24) + -1 + iVar11) / iVar11 & 0xffff);
        if (1 < *(short*)((int)param_1_00 + 0x38)) {
            iVar10 = *(short*)((int)param_1_00 + 0x42) - *(short*)((int)param_1_00 + 0x40);
            if ((-1 < iVar10) && (iVar10 < iVar11 * 3)) {
                FhXCall.graphicGetTime.fnptr!();
                fVar12 = MathF.Cos((float)FhXCall.graphicGetTime.fnptr!());
                local_48 = (int)MathF.Round((float)(fVar12 * 32.0f + 96.0f));
                color = (uint)((local_48 << 24) | 0x00808080);
                RVar4 = color;
                RVar30 = RVar4;
                fVar27 = 156.0f;
                fVar24 = 1920.0f;
                fVar21 = 105.0f;
                fVar19 = 1619.0f;
                RVar30 = RVar4;
                fVar13 = FhXCall.graphicUiRemapY2.fnptr!(50.0f);
                fVar16 = *(short*)((int)param_1_00 + 0x62);
                fVar14 = FhXCall.graphicUiRemapY2.fnptr!(((*(short*)((int)param_1_00 + 0x42) - *(short*)((int)param_1_00 + 0x40)) /
                    *(short*)((int)param_1_00 + 0x38) * 0x34) + 835.0f);
                fVar15 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                FhXCall.TOMkpShapeXYWHUVC2.fnptr!(0xffffffff, fVar15 + ((*(short*)((int)param_1_00 + 0x42) - *(short*)((int)param_1_00 + 0x40)) %
                    *(short*)((int)param_1_00 + 0x38) * *(short*)((int)param_1_00 + 0x62)), fVar14, fVar16, fVar13, fVar19, fVar21, fVar24,
                fVar27, RVar4, RVar30);
            }
            local_8 = 0.0f;
            local_c = 0.0f;
            do {
                sVar1 = *(short*)((int)fVar2 + 0x62);
                fVar13 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                fVar16 = sVar1;
                fVar16 = (local_10 * (fVar13 + fVar16)) / 0.1f - fVar16;
                param_1_00 = (uint)(float)-sVar1;
                local_14 = param_1_00;
                fVar13 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                param_1_00 = (uint)fVar16;
                if ((param_1_00 <= fVar16) && fVar13 < fVar16) {
                    param_1_00 = (uint)FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                }
                local_20 = (int)local_c;
                local_1c = local_20 + 835.0f;
                fVar24 = 50.0f;
                fVar21 = 438.0f;
                fVar19 = 0.0f;
                fVar15 = 0.0f;
                fVar13 = FhXCall.graphicUiRemapY2.fnptr!(50.0f);
                fVar16 = *(short*)((int)fVar2 + 0x62);
                fVar14 = FhXCall.graphicUiRemapY2.fnptr!(local_1c);
                FhXCall.TOMkpShapeXYWHUVC2.fnptr!(0xffffffff, param_1_00, fVar14, fVar16, fVar13, fVar15, fVar19, fVar21, fVar24, 0x80808080, 0x60808080);
                fVar13 = (int)local_8 * 53.0f + 315.0f;
                fVar24 = 1788.0f;
                fVar16 = (int)local_8 * 53.0f + 270.0f;
                fVar21 = 1553.0f;
                fVar14 = FhXCall.graphicUiRemapY2.fnptr!(44.0f);
                fVar15 = FhXCall.graphicUiRemapX2.fnptr!(234.0f);
                fVar19 = FhXCall.graphicUiRemapY2.fnptr!(local_20 + 838.0f);
                FhXCall.TOMkpShapeXYWHUVC2.fnptr!(0xffffffff, param_1_00, fVar19, fVar15, fVar14, fVar21, fVar16, fVar24, fVar13, 0x40808080, 0x40808080);
                sVar1 = *(short*)((int)fVar2 + 0x62);
                fVar16 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                fVar16 = ((fVar16 + (sVar1 * 2)) * local_10) / 0.1f - sVar1;
                fVar13 = -sVar1;
                local_14 = fVar13;
                fVar14 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                fVar13 = fVar16;
                if ((fVar13 <= fVar16) && fVar14 + *(short*)((int)fVar2 + 0x62) < fVar16) {
                    fVar16 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                    fVar13 = fVar16 + *(short*)((int)fVar2 + 0x62);
                }
                fVar27 = 50.0f;
                fVar24 = 438.0f;
                fVar21 = 0.0f;
                fVar19 = 0.0f;
                fVar14 = FhXCall.graphicUiRemapY2.fnptr!(50.0f);
                fVar16 = *(short*)((int)fVar2 + 0x62);
                fVar15 = FhXCall.graphicUiRemapY2.fnptr!(local_1c);
                FhXCall.TOMkpShapeXYWHUVC2.fnptr!(0xffffffff, fVar13, fVar15, fVar16, fVar14, fVar19, fVar21, fVar24, fVar27, 0x60808080, 0x60808080);
                local_10 = local_10 - 0.1f;
                local_8 = (int)local_8 + 1;
                local_c = (int)local_c + 0x34;
            } while ((int)local_c < 0x9c);
            fVar16 = *(float*)((int)fVar2 + 0xe0);
            if (!float.IsNaN(fVar16) && (0.3f < fVar16) != (fVar16 == 0.3f)) {
                local_8 = 0.0f;
                local_1c = 0.0f;
                do {
                    fVar15 = local_1c;
                    fVar24 = (int)local_8 + 1;
                    local_20 = (int)fVar24;
                    uVar33 = 0x40808080;
                    uVar31 = 0x808080;
                    fVar16 = local_20 * 20.0f;
                    local_24 = (int)local_8;
                    fVar13 = local_24 * 0.0f;
                    local_1c = (int)local_1c;
                    local_10 = local_1c + 835.0f;
                    uVar28 = 40.0f;
                    uVar25 = 40.0f;
                    fVar22 = 3.0f;
                    fVar20 = 210.0f;
                    fVar19 = fVar13;
                    fVar21 = fVar16;
                    local_18 = fVar13;
                    fVar27 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                    fVar14 = *(short*)((int)fVar2 + 0x62) * 0.5f;
                    fVar17 = FhXCall.graphicUiRemapY2.fnptr!(local_10);
                    fVar18 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                    FhXCall.DrawWaterWaveShapeC2.fnptr!(fVar18, fVar17, fVar14, fVar27, fVar19, fVar21, fVar20, fVar22, uVar25, uVar28, (uint)uVar31, uVar33);
                    fVar13 = fVar13 + 210.0f;
                    uVar33 = 0x808080;
                    uVar31 = 0x40808080;
                    uVar28 = 40.0f;
                    uVar25 = 40.0f;
                    fVar20 = 3.0f;
                    fVar18 = 210.0f;
                    fVar19 = fVar16;
                    local_14 = fVar13;
                    fVar21 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                    fVar14 = *(short*)((int)fVar2 + 0x62) * 0.5f;
                    fVar27 = FhXCall.graphicUiRemapY2.fnptr!(local_10);
                    fVar17 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                    FhXCall.DrawWaterWaveShapeC2.fnptr!(*(short*)((int)fVar2 + 0x62) * 0.5f + fVar17, fVar27, fVar14, fVar21, fVar13, fVar19, fVar18, fVar20, uVar25, uVar28, (uint)uVar31, uVar33);
                    fVar13 = local_20 * 50.0f;
                    uVar33 = 0x40808080;
                    uVar31 = 0x808080;
                    local_8 = local_1c + 880.0f;
                    uVar28 = 40.0f;
                    uVar25 = 40.0f;
                    fVar20 = 3.0f;
                    fVar18 = 210.0f;
                    fVar19 = local_18;
                    local_c = fVar13;
                    fVar21 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                    fVar14 = *(short*)((int)fVar2 + 0x62) * 0.5f;
                    fVar27 = FhXCall.graphicUiRemapY2.fnptr!(local_8);
                    fVar17 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                    FhXCall.DrawWaterWaveShapeC2.fnptr!(fVar17, fVar27, fVar14, fVar21, fVar19, fVar13, fVar18, fVar20, uVar25, uVar28, (uint)uVar31, uVar33);
                    uVar33 = 0x808080;
                    uVar31 = 0x40808080;
                    uVar28 = 40.0f;
                    uVar25 = 40.0f;
                    fVar20 = 3.0f;
                    fVar18 = 210.0f;
                    fVar14 = local_14;
                    fVar19 = local_c;
                    fVar21 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                    fVar13 = *(short*)((int)fVar2 + 0x62) * 0.5f;
                    fVar27 = FhXCall.graphicUiRemapY2.fnptr!(local_8);
                    fVar17 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                    FhXCall.DrawWaterWaveShapeC2.fnptr!(*(short*)((int)fVar2 + 0x62) * 0.5f + fVar17, fVar27, fVar13, fVar21, fVar14, fVar19, fVar18, fVar20, uVar25, uVar28, (uint)uVar31, uVar33);
                    fVar13 = local_24 * 20.0f;
                    uVar33 = 0x40808080;
                    uVar31 = 0x808080;
                    uVar28 = 40.0f;
                    uVar25 = 40.0f;
                    fVar22 = 3.0f;
                    fVar20 = 210.0f;
                    fVar19 = fVar13;
                    fVar21 = fVar16;
                    local_24 = fVar13;
                    fVar27 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                    fVar14 = *(short*)((int)fVar2 + 0x62) * 0.5f;
                    fVar17 = FhXCall.graphicUiRemapY2.fnptr!(local_10);
                    fVar18 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                    FhXCall.DrawWaterWaveShapeC2.fnptr!(fVar18 + *(short*)((int)fVar2 + 0x62), fVar17, fVar14, fVar27, fVar19, fVar21, fVar20, fVar22, uVar25, uVar28, (uint)uVar31, uVar33);
                    fVar13 = fVar13 + 210.0f;
                    uVar33 = 0x808080;
                    uVar31 = 0x40808080;
                    uVar28 = 40.0f;
                    uVar25 = 40.0f;
                    fVar18 = 3.0f;
                    fVar17 = 210.0f;
                    local_20 = fVar13;
                    fVar19 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                    fVar14 = *(short*)((int)fVar2 + 0x62) * 0.5f;
                    fVar21 = FhXCall.graphicUiRemapY2.fnptr!(local_10);
                    fVar27 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                    FhXCall.DrawWaterWaveShapeC2.fnptr!(*(short*)((int)fVar2 + 0x62) * 1.5f + fVar27, fVar21, fVar14, fVar19, fVar13, fVar16, fVar17, fVar18, uVar25, uVar28, (uint)uVar31, uVar33);
                    uVar33 = 0x40808080;
                    uVar31 = 0x808080;
                    uVar28 = 40.0f;
                    uVar25 = 40.0f;
                    fVar18 = 3.0f;
                    fVar17 = 210.0f;
                    fVar13 = local_24;
                    fVar14 = local_c;
                    fVar19 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                    fVar16 = *(short*)((int)fVar2 + 0x62) * 0.5f;
                    fVar21 = FhXCall.graphicUiRemapY2.fnptr!(local_8);
                    fVar27 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                    FhXCall.DrawWaterWaveShapeC2.fnptr!(fVar27 + *(short*)((int)fVar2 + 0x62), fVar21, fVar16, fVar19, fVar13, fVar14, fVar17, fVar18, uVar25, uVar28, (uint)uVar31, uVar33);
                    uVar33 = 0x808080;
                    uVar31 = 0x40808080;
                    uVar28 = 40.0f;
                    uVar25 = 40.0f;
                    fVar18 = 3.0f;
                    fVar17 = 210.0f;
                    fVar13 = local_20;
                    fVar14 = local_c;
                    fVar19 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                    fVar16 = *(short*)((int)fVar2 + 0x62) * 0.5f;
                    fVar21 = FhXCall.graphicUiRemapY2.fnptr!(local_8);
                    fVar27 = FhXCall.graphicUiRemapX2.fnptr!(154.0f);
                    FhXCall.DrawWaterWaveShapeC2.fnptr!(*(short*)((int)fVar2 + 0x62) * 1.5f + fVar27, fVar21, fVar16, fVar19, fVar13, fVar14, fVar17, fVar18, uVar25, uVar28, (uint)uVar31, uVar33);
                    local_1c = (int)fVar15 + 0x34;
                    local_8 = fVar24;
                } while ((int)local_1c < 0x9c);
            }
        }
        iVar11 = (short)local_28;
        iVar10 = *(short*)((int)fVar2 + 0x3a);
        iVar5 = *(short*)((int)fVar2 + 0x40) / *(short*)((int)fVar2 + 0x38);
        fVar16 = FhXCall.graphicUiRemapY2.fnptr!(154.0f);
        fVar13 = FhXCall.graphicUiRemapX2.fnptr!(8.0f);
        fVar14 = FhXCall.graphicUiRemapY2.fnptr!(835.0f);
        fVar15 = FhXCall.graphicUiRemapX2.fnptr!(150.0f);
        FhXCall.DrawCrossMenuScrollParts.fnptr!(fVar15 + *(short*)((int)fVar2 + 0x62), fVar14, fVar13, fVar16, iVar5, iVar10, iVar11);
        iVar11 = (int)*(float*)((int)fVar2 + 0x74);
        iVar10 = (int)*(float*)((int)fVar2 + 0x70);
        iVar5 = (int)*(float*)((int)fVar2 + 0x6c);
        iVar6 = (int)*(float*)((int)fVar2 + 0x68);
        FhXCall.TOMakePktScissor.fnptr!(iVar6, iVar5, iVar10, iVar11);
        //(**(code**)((int)fVar2 + 0x88))(fVar2);
        func_addr = Marshal.ReadIntPtr((IntPtr)fVar2, 0x88);
        var updateMenu = Marshal.GetDelegateForFunctionPointer<updateMenu>(func_addr);
        updateMenu((IntPtr)fVar2);
        uVar31 = *(short*)((int)fVar2 + 0x40);
        local_20 = *(int*)((int)fVar2 + 0x24);
        local_10 = local_20;
        if (uVar31 <= (int)local_20) {
            local_10 = uVar31 < 0 ? 0 : uVar31;
        }
        uVar31 = *(short*)((int)fVar2 + 0x38) * *(short*)((int)fVar2 + 0x3a) + (int)local_10;
        if (uVar31 <= (int)local_20) {
            local_20 = uVar31 < 0 ? 0 : uVar31;
        }
        if ((int)local_10 < (int)local_20) {
            do {
                sVar1 = *(short*)(*(int*)((int)fVar2 + 0x20) + (int)local_10 * 2);
                uVar31 = FhXCall.TOCheckBtlCommandUse.fnptr!(*(short*)((int)fVar2 + 8), (uint)(int)sVar1);
                fVar16 = local_10;
                if ((sVar1 != 0xff) && (uVar31 != -4)) {
                    local_28 = FhXCall.MsGetComData.fnptr!(*(short*)(*(int*)((int)fVar2 + 0x20) + (int)local_10 * 2), &local_2c);
                    sVar1 = *(short*)((int)fVar2 + 0x38);
                    pbVar7 = local_2c + local_28->name.standard.text_offset;
                    uVar33 = (uint)(fVar16 == *(short*)((int)fVar2 + 0x42) ? 1 : 0);
                    local_8 = fVar16 % sVar1 * *(short*)((int)fVar2 + 0x62);
                    iVar11 = (int)(*(float*)((int)fVar2 + 0x68));
                    local_14 = (int)local_8 + iVar11;
                    local_8 = local_14;
                    fVar13 = FhXCall.graphicUiRemapY2.fnptr!((float)((((int)fVar16 - *(short*)((int)fVar2 + 0x40)) / (int)sVar1) * 0x34));
                    iVar11 = (int)(fVar13 + *(float*)((int)fVar2 + 0x7c));
                    local_18 = 0.0f;
                    if (0 < *(short*)((int)fVar2 + 0x28)) {
                        local_1c = (int)fVar2 + 0x2c;
                        do {
                            fVar13 = local_18;
                            switch (*(byte*)((int)local_1c + 1)) {
                                case 1:
                                    bVar32 = 0x80;
                                    bVar3 = local_28->icon;
                                    bVar29 = 0x80;
                                    bVar26 = 0x80;
                                    bVar23 = 0x80;
                                    fVar15 = FhXCall.graphicUiRemapY2.fnptr!(36.0f);
                                    fVar19 = FhXCall.graphicUiRemapX2.fnptr!(29.0f);
                                    fVar14 = FhXCall.graphicUiRemapY2.fnptr!(3.0f);
                                    fVar14 = fVar14 + iVar11;
                                    fVar21 = FhXCall.graphicUiRemapX2.fnptr!(37.0f);
                                    FhXCall.DrawCrossMenuIconXYWHRGBA.fnptr!(fVar21 + local_14, fVar14, fVar19, fVar15, bVar3, bVar23, bVar26, bVar29, bVar32);
                                    break;
                                case 2:
                                    local_24 = FhGCall.MsGetSaveItemNum.fnptr!((uint)(int)*(short*)(*(int*)((int)fVar2 + 0x20) + (int)fVar16 * 2));
                                    if ((0 < (int)local_24) || (*(short*)((int)fVar2 + 0x2a) == 1)) {
                                        iVar10 = *(short*)((int)fVar2 + 0x62) + (int)local_8;
                                        uVar8 = (uint)local_c & 0xff;
                                        uVar25 = 1.0f;
                                        fVar19 = 0.78f;
                                        fVar14 = iVar11;
                                        fVar15 = FhXCall.graphicUiRemapX2.fnptr!(28.0f);
                                        FhXCall.ToMakeBtlEasyDigitRight.fnptr!((int)local_24, iVar10 - fVar15, fVar14, (int)uVar8, fVar19, uVar25);
                                    }
                                    break;
                                case 4:
                                    local_24 = FhXCall.MsGetCommandMP.fnptr!(*(short*)((int)fVar2 + 8), local_28);
                                    if ((0 < (int)local_24) || (*(short*)((int)fVar2 + 0x2a) == 1)) {
                                        iVar10 = *(short*)((int)fVar2 + 0x62) + (int)local_8;
                                        uVar8 = (uint)local_c & 0xff;
                                        uVar25 = 1.0f;
                                        fVar19 = 0.78f;
                                        fVar14 = iVar11;
                                        fVar15 = FhXCall.graphicUiRemapX2.fnptr!(28.0f);
                                        FhXCall.ToMakeBtlEasyDigitRight.fnptr!((int)local_24, iVar10 - fVar15, fVar14, (int)uVar8, fVar19, uVar25);
                                    }
                                    break;
                                case 5:
                                    local_24 = FhXCall.MsGetRamChrHP.fnptr!(*(short*)(*(int*)((int)fVar2 + 0x20) + (int)fVar16 * 2));
                                    if ((0 < (int)local_24) || (*(short*)((int)fVar2 + 0x2a) == 1)) {
                                        iVar10 = *(short*)((int)fVar2 + 0x62) + (int)local_8;
                                        uVar8 = (uint)local_c & 0xff;
                                        uVar25 = 1.0f;
                                        fVar19 = 0.78f;
                                        fVar14 = iVar11;
                                        fVar15 = FhXCall.graphicUiRemapX2.fnptr!(28.0f);
                                        FhXCall.ToMakeBtlEasyDigitRight.fnptr!((int)local_24, iVar10 - fVar15, fVar14, (int)uVar8, fVar19, uVar25);
                                    }
                                    break;
                                case 6:
                                    local_24 = FhXCall.MsGetRamChrMP.fnptr!(*(short*)(*(int*)((int)fVar2 + 0x20) + (int)fVar16 * 2));
                                    if ((0 < (int)local_24) || (*(short*)((int)fVar2 + 0x2a) == 1)) {
                                        iVar10 = *(short*)((int)fVar2 + 0x62) + (int)local_8;
                                        uVar8 = (uint)local_c & 0xff;
                                        uVar25 = 1.0f;
                                        fVar19 = 0.78f;
                                        fVar14 = iVar11;
                                        fVar15 = FhXCall.graphicUiRemapX2.fnptr!(28.0f);
                                        FhXCall.ToMakeBtlEasyDigitRight.fnptr!((int)local_24, iVar10 - fVar15, fVar14, (int)uVar8, fVar19, uVar25);
                                    }
                                    break;
                                case 7:
                                    pSVar9 = FhXCall.MsGetSaveWeapon.fnptr!((uint)(int)*(short*)(*(int*)((int)fVar2 + 0x20) + (int)fVar16 * 2), (nint)(&local_2c));
                                    local_24 = iVar11;
                                    bVar32 = 0x80;
                                    bVar29 = 0x80;
                                    bVar26 = 0x80;
                                    fVar14 = local_14;
                                    bVar23 = 0x80;
                                    if (pSVar9->owner == 7) {
                                        bVar3 = (byte)(37 * 2 + 2 + pSVar9->type);
                                    }
                                    else {
                                        bVar3 = (byte)(pSVar9->owner * 2 + 1 + pSVar9->type);
                                    }
                                    fVar15 = FhXCall.graphicUiRemapY2.fnptr!(36.0f);
                                    fVar19 = FhXCall.graphicUiRemapX2.fnptr!(29.0f);
                                    fVar13 = FhXCall.graphicUiRemapY2.fnptr!(2.0f);
                                    fVar13 = fVar13 + local_24;
                                    fVar21 = FhXCall.graphicUiRemapX2.fnptr!(37.0f);
                                    FhXCall.DrawCrossMenuIconXYWHRGBA.fnptr!(fVar21 + fVar14, fVar13, fVar19, fVar15, bVar3, bVar23, bVar26, bVar29, bVar32);
                                    fVar13 = local_18;
                                    if (pSVar9->owner == pSVar9->equipped_by) {
                                        bVar32 = 0x80;
                                        bVar29 = 0x80;
                                        bVar26 = 0x80;
                                        bVar23 = 0x80;
                                        bVar3 = 0x31;
                                        fVar15 = FhXCall.graphicUiRemapY2.fnptr!(36.0f);
                                        fVar19 = FhXCall.graphicUiRemapX2.fnptr!(29.0f);
                                        fVar13 = FhXCall.graphicUiRemapY2.fnptr!(2.0f);
                                        fVar13 = fVar13 + local_24;
                                        fVar21 = FhXCall.graphicUiRemapX2.fnptr!(37.0f);
                                        FhXCall.DrawCrossMenuIconXYWHRGBA.fnptr!(fVar21 + fVar14, fVar13, fVar19, fVar15, bVar3, bVar23, bVar26, bVar29, bVar32);
                                        fVar13 = local_18;
                                    }
                                    break;
                                case 0x10:
                                    local_c = (uVar31 < 0 ? 1.0f : 0.0f);
                                    iVar10 = 0;
                                    if (*(int*)((int)fVar2 + 0xe4) == 0) {
                                        FhXCall.FUN_00904ba0.fnptr!(pbVar7, (float)(*(short*)((int)fVar2 + 0x62) * 0.5 + local_14), iVar11,
                                        *(short*)((int)fVar2 + 0x66), (byte)(uVar31 < 0 ? 1 : 0), 0.78f, (uint)1.0f, 1, (int)uVar33, 0);
                                    }
                                    else {
                                        iVar5 = 0;
                                        uVar25 = 1.0f;
                                        fVar24 = 0.78f;
                                        fVar14 = *(short*)((int)fVar2 + 0x66);
                                        fVar15 = iVar11;
                                        fVar19 = local_c;
                                        uVar8 = uVar33;
                                        fVar21 = FhXCall.graphicUiRemapX2.fnptr!(72.0f);
                                        FhXCall.FUN_00904ba0.fnptr!(pbVar7, fVar21 + local_14, fVar15, fVar14, (byte)fVar19, fVar24, (uint)uVar25, iVar5, (int)uVar8,
                                        iVar10);
                                    }
                                    break;
                            }
                            local_1c = (int)local_1c + 2;
                            local_18 = (int)fVar13 + 1;
                        } while ((int)local_18 < *(short*)((int)fVar2 + 0x28));
                    }
                }
                local_10 = (int)local_10 + 1;
            } while ((int)local_10 < (int)local_20);
        }
        return 0;
    }

    // Gear Ability Preview in Shops
    void h_FUN_008d85f0(void* param_1, int param_2) {
        void* pvVar1;
        Equipment* pSVar2;
        uint gear_inv_idx;
        Equipment* pSVar3;
        byte* pbVar4;
        float fVar5;
        float fVar6;
        float fVar7;
        float fVar8;
        float* pfVar9;
        Equipment* pSVar10;
        float fVar11;
        float scale;
        int iVar12;
        byte* local_14;
        byte* local_10;
        float local_c;
        float local_8;

        int param_1_00 = (int)param_1;
        if (7 < DAT_0186ab60) {
            return;
        }
        pvVar1 = _TkMn2GetExcelData.fnptr!(*p_DAT_0186aadc, (ExcelDataFile*)*(nint*)p_DAT_0186ab68);
        if (param_2 == 0) {
            pSVar2 = FhXCall.MsGetSaveWeapon.fnptr!(p_TkMenuItemData_ARRAY_01597730[*(short*)(param_1_00 + 0x48)].item_id, (nint)(&local_10));
        }
        else {
            pSVar2 = (Equipment*)FhXCall.FUN_008d9140.fnptr!(*(ushort*)((int)pvVar1 + *(short*)(param_1_00 + 0x48) * 2 + 2));
        }
        if (pSVar2->type == 0) {
            gear_inv_idx = FhXCall.FUN_008a9c20.fnptr!((int)DAT_0186ab60);
        }
        else {
            gear_inv_idx = FhXCall.FUN_008a97d0.fnptr!((int)DAT_0186ab60);
        }
        if (gear_inv_idx == 0xff) {
            pSVar3 = (Equipment*)0x0;
        }
        else {
            pSVar3 = FhXCall.MsGetSaveWeapon.fnptr!(gear_inv_idx, (nint)(&local_14));
        }
        iVar12 = 2;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(60.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(740.0f);
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(295.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(1144.0f);
        FhXCall.TODrawMenuPlateXYWHType.fnptr!(fVar8, fVar7, fVar6, fVar5, iVar12);
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(36.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(430.0f);
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(310.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(1299.0f);
        FhXCall.FUN_008f8bb0.fnptr!(0x12, fVar8, fVar7, fVar6, fVar5);
        if (param_2 == 0) {
            if (pSVar3 == (Equipment*)0x0) {
                iVar12 = 9;
                fVar5 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
                fVar6 = FhXCall.graphicUiRemapX2.fnptr!(700.0f);
                fVar7 = FhXCall.graphicUiRemapY2.fnptr!(231.0f);
                fVar8 = FhXCall.graphicUiRemapX2.fnptr!(1164.0f);
                FhXCall.TODrawMenuPlateXYWHType.fnptr!(fVar8, fVar7, fVar6, fVar5, iVar12);
                pfVar9 = &local_c;
                scale = 0.78f;
                fVar11 = 0.0f;
                pbVar4 = FhXCall.FUN_008bee40.fnptr!(0x17);
                FhXCall.ToGetBtlEasyFontWidth.fnptr!(pbVar4, pfVar9, (int)fVar11, scale);
                fVar7 = 0.78f;
                pSVar3 = (Equipment*)0x0;
                fVar6 = FhXCall.graphicUiRemapY2.fnptr!(243.0f);
                fVar5 = FhXCall.graphicUiRemapX2.fnptr!(1514.0f);
                fVar5 = fVar5 - local_c * 0.5f;
                local_8 = fVar5;
                goto LAB_008d8976;
            }
        }
        else if (pSVar3 == (Equipment*)0x0) {
            iVar12 = 9;
            fVar5 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
            fVar6 = FhXCall.graphicUiRemapX2.fnptr!(700.0f);
            fVar7 = FhXCall.graphicUiRemapY2.fnptr!(231.0f);
            fVar8 = FhXCall.graphicUiRemapX2.fnptr!(1164.0f);
            FhXCall.TODrawMenuPlateXYWHType.fnptr!(fVar8, fVar7, fVar6, fVar5, iVar12);
            pfVar9 = &local_8;
            fVar11 = 0.78f;
            pSVar10 = pSVar3;
            pbVar4 = FhXCall.FUN_008bee40.fnptr!(0x17);
            FhXCall.ToGetBtlEasyFontWidth.fnptr!(pbVar4, pfVar9, (int)pSVar10, fVar11);
            fVar7 = 0.78f;
            fVar6 = FhXCall.graphicUiRemapY2.fnptr!(243.0f);
            fVar5 = FhXCall.graphicUiRemapX2.fnptr!(1514.0f);
            fVar5 = fVar5 - local_8 * 0.5f;
            local_c = fVar5;
            goto LAB_008d8976;
        }
        pSVar10 = pSVar3;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(363.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(1144.0f);
        FhXCall.FUN_008d8a70.fnptr!(fVar6, fVar5, pSVar10);
        iVar12 = 9;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(64.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(700.0f);
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(231.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(1164.0f);
        FhXCall.TODrawMenuPlateXYWHType.fnptr!(fVar8, fVar7, fVar6, fVar5, iVar12);
        fVar7 = 0.0f;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(231.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(1164.0f);
        _DrawCrossMenuIconWeaponName2.fnptr!(&pSVar3->name_id, fVar6, fVar5, (byte)fVar7);
    LAB_008d8976:
        pbVar4 = FhXCall.FUN_008bee40.fnptr!(0x17);
        FhXCall.ToMakeBtlEasyFont.fnptr!(pbVar4, fVar5, fVar6, 0, fVar7);
        goto LAB_008d898c;
    LAB_008d898c:
        iVar12 = 2;
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(60.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(740.0f);
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(659.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(970.0f);
        FhXCall.TODrawMenuPlateXYWHType.fnptr!(fVar8, fVar7, fVar6, fVar5, iVar12);
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(36.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(430.0f);
        fVar7 = FhXCall.graphicUiRemapY2.fnptr!(671.0f);
        fVar8 = FhXCall.graphicUiRemapX2.fnptr!(1125.0f);
        FhXCall.FUN_008f8bb0.fnptr!(0x13, fVar8, fVar7, fVar6, fVar5);
        fVar5 = FhXCall.graphicUiRemapY2.fnptr!(727.0f);
        fVar6 = FhXCall.graphicUiRemapX2.fnptr!(970.0f);
        FhXCall.FUN_008d8a70.fnptr!(fVar6, fVar5, pSVar2);
        return;
    }
}