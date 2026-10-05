// SPDX-License-Identifier: MIT

namespace Fahrenheit.Mods.Seymour;

public unsafe partial class SeymourModule : FhModule {
    // Delegates that aren't currently upstreamed to Fahrenheit

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void d_graphicDrawUIElement(graphicDrawUIAbmapElement_param1* param_1, byte* param_2, int param_3, int param_4, int param_5);
    public static FhMethodHandle<d_graphicDrawUIElement> graphicDrawUIElement
        => new ( new FhMethodLocation("FFX.exe", 0x23EEE0) );
    [StructLayout(LayoutKind.Sequential)]
    public struct graphicDrawUIAbmapElement_param1 {
        public InlineArray4<float> floats0;
        public InlineArray4<int  > ints0;
        public InlineArray4<float> floats1;
        public InlineArray4<int  > ints1;
        public InlineArray4<float> floats2;
        public InlineArray4<int  > ints2;
        public InlineArray4<float> floats3;
        public InlineArray4<int  > ints3;
    }


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void* d_TkMn2GetExcelData(int req_elem_idx, ExcelDataFile* excel_data_ptr);
    public static FhMethodHandle<d_TkMn2GetExcelData> TkMn2GetExcelData
        => new ( new FhMethodLocation("FFX.exe", 0x4C1AF0) );
    [StructLayout(LayoutKind.Sequential)]
    public struct ExcelDataFile {
        public ushort chunk_count;
        private byte __0x02;
        private byte __0x03;
        private byte __0x04;
        private byte __0x05;
        private byte __0x06;
        private byte __0x07;
        public ExcelHeader chunk_headers;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ExcelHeader {
        public ushort first_idx;
        public ushort last_idx;
        public ushort element_size;
        public ushort data_length;
        public nint   data_start;

        public readonly int length => last_idx + 1 - first_idx;
    }


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate SphereGridPlyParam* d_FUN_00798800(int chr_id);
    public static FhMethodHandle<d_FUN_00798800> FUN_00798800
        => new ( new FhMethodLocation("FFX.exe", 0x3987F0) );
    [StructLayout(LayoutKind.Sequential, Size = 0x1C)]
    public struct SphereGridPlyParam {
        [InlineArray(12)]
        public struct AbilityMap {
            private byte _data;
        }

        public uint hp; // in multiples of 50
        public uint mp; // in multiples of 5
        public byte strength;
        public byte defense;
        public byte magic;
        public byte magic_defense;
        public byte agility;
        public byte luck;
        public byte evasion;
        public byte accuracy;
        public AbilityMap abmap;
    }


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SphereGridPlyParam* d_MsGetChrAbilityMap(int chr_id, SaveParam* save_param);
    private static FhMethodHandle<d_MsGetChrAbilityMap> MsGetChrAbilityMap
        => new(new FhMethodLocation("FFX.exe", 0x385B60));
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x3C)]
    public struct SaveParam
    {
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


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_004a8f40(uint param_1);
    public static FhMethodHandle<d_FUN_004a8f40> FUN_004a8f40
        => new ( new FhMethodLocation("FFX.exe", 0x4A8F40) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate byte* d_MsGetSaveInParty(int* out_length);
    public static FhMethodHandle<d_MsGetSaveInParty> MsGetSaveInParty
        => new ( new FhMethodLocation("FFX.exe", 0x385270) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate byte* d_MsGetSaveOutParty(int* out_length);
    public static FhMethodHandle<d_MsGetSaveOutParty> MsGetSaveOutParty
        => new ( new FhMethodLocation("FFX.exe", 0x3852D0) );
}