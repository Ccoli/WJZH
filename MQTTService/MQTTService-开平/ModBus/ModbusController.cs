using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ModBus;
using MQTTClient;
//using TaskManager.Domain.Dal;
//using TaskManager.Domain.Model;
//using XXF.ProjectTool;
using MyUtil.log;

namespace ModBus
{

    public class ModbusController
    {
        public static MyUtil.log.Log logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MQTTClientModule mqttclient = new MQTTClientModule();
        #region 属性
        /// <summary>
        /// 状态
        /// </summary>
        public AppStatus Status = AppStatus.停止;
        /// <summary>
        /// COM操作对象
        /// </summary>
        private SerialPort sp = new SerialPort();
        /// <summary>
        /// 锁
        /// </summary>
        private static Object o = new Object();
        /// <summary>
        /// CRC验证表
        /// </summary>
        public byte[] crc_table = new byte[512];
        /// <summary>
        /// 数据集合
        /// </summary>
        private Dictionary<Int16, Int16> DicData = null;
        /// <summary>
        /// 从机地址
        /// </summary>
        private byte SlaveID = 1;
        /// <summary>
        /// 数据发送对象配置信息
        /// </summary>
        private ArrayList DataList = null;
        /// <summary>
        /// COM口配置信息
        /// </summary>
        private ComSetting Setting = null;
        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary> 
        public ModbusController(RecivedConfigurationTable configuration)
        {
            #region 初始化CRC
            crc_table[0] = 0x0;
            crc_table[1] = 0xC1;
            crc_table[2] = 0x81;
            crc_table[3] = 0x40;
            crc_table[4] = 0x1;
            crc_table[5] = 0xC0;
            crc_table[6] = 0x80;
            crc_table[7] = 0x41;
            crc_table[8] = 0x1;
            crc_table[9] = 0xC0;
            crc_table[10] = 0x80;
            crc_table[11] = 0x41;
            crc_table[12] = 0x0;
            crc_table[13] = 0xC1;
            crc_table[14] = 0x81;
            crc_table[15] = 0x40;
            crc_table[16] = 0x1;
            crc_table[17] = 0xC0;
            crc_table[18] = 0x80;
            crc_table[19] = 0x41;
            crc_table[20] = 0x0;
            crc_table[21] = 0xC1;
            crc_table[22] = 0x81;
            crc_table[23] = 0x40;
            crc_table[24] = 0x0;
            crc_table[25] = 0xC1;
            crc_table[26] = 0x81;
            crc_table[27] = 0x40;
            crc_table[28] = 0x1;
            crc_table[29] = 0xC0;
            crc_table[30] = 0x80;
            crc_table[31] = 0x41;
            crc_table[32] = 0x1;
            crc_table[33] = 0xC0;
            crc_table[34] = 0x80;
            crc_table[35] = 0x41;
            crc_table[36] = 0x0;
            crc_table[37] = 0xC1;
            crc_table[38] = 0x81;
            crc_table[39] = 0x40;
            crc_table[40] = 0x0;
            crc_table[41] = 0xC1;
            crc_table[42] = 0x81;
            crc_table[43] = 0x40;
            crc_table[44] = 0x1;
            crc_table[45] = 0xC0;
            crc_table[46] = 0x80;
            crc_table[47] = 0x41;
            crc_table[48] = 0x0;
            crc_table[49] = 0xC1;
            crc_table[50] = 0x81;
            crc_table[51] = 0x40;
            crc_table[52] = 0x1;
            crc_table[53] = 0xC0;
            crc_table[54] = 0x80;
            crc_table[55] = 0x41;
            crc_table[56] = 0x1;
            crc_table[57] = 0xC0;
            crc_table[58] = 0x80;
            crc_table[59] = 0x41;
            crc_table[60] = 0x0;
            crc_table[61] = 0xC1;
            crc_table[62] = 0x81;
            crc_table[63] = 0x40;
            crc_table[64] = 0x1;
            crc_table[65] = 0xC0;
            crc_table[66] = 0x80;
            crc_table[67] = 0x41;
            crc_table[68] = 0x0;
            crc_table[69] = 0xC1;
            crc_table[70] = 0x81;
            crc_table[71] = 0x40;
            crc_table[72] = 0x0;
            crc_table[73] = 0xC1;
            crc_table[74] = 0x81;
            crc_table[75] = 0x40;
            crc_table[76] = 0x1;
            crc_table[77] = 0xC0;
            crc_table[78] = 0x80;
            crc_table[79] = 0x41;
            crc_table[80] = 0x0;
            crc_table[81] = 0xC1;
            crc_table[82] = 0x81;
            crc_table[83] = 0x40;
            crc_table[84] = 0x1;
            crc_table[85] = 0xC0;
            crc_table[86] = 0x80;
            crc_table[87] = 0x41;
            crc_table[88] = 0x1;
            crc_table[89] = 0xC0;
            crc_table[90] = 0x80;
            crc_table[91] = 0x41;
            crc_table[92] = 0x0;
            crc_table[93] = 0xC1;
            crc_table[94] = 0x81;
            crc_table[95] = 0x40;
            crc_table[96] = 0x0;
            crc_table[97] = 0xC1;
            crc_table[98] = 0x81;
            crc_table[99] = 0x40;
            crc_table[100] = 0x1;
            crc_table[101] = 0xC0;
            crc_table[102] = 0x80;
            crc_table[103] = 0x41;
            crc_table[104] = 0x1;
            crc_table[105] = 0xC0;
            crc_table[106] = 0x80;
            crc_table[107] = 0x41;
            crc_table[108] = 0x0;
            crc_table[109] = 0xC1;
            crc_table[110] = 0x81;
            crc_table[111] = 0x40;
            crc_table[112] = 0x1;
            crc_table[113] = 0xC0;
            crc_table[114] = 0x80;
            crc_table[115] = 0x41;
            crc_table[116] = 0x0;
            crc_table[117] = 0xC1;
            crc_table[118] = 0x81;
            crc_table[119] = 0x40;
            crc_table[120] = 0x0;
            crc_table[121] = 0xC1;
            crc_table[122] = 0x81;
            crc_table[123] = 0x40;
            crc_table[124] = 0x1;
            crc_table[125] = 0xC0;
            crc_table[126] = 0x80;
            crc_table[127] = 0x41;
            crc_table[128] = 0x1;
            crc_table[129] = 0xC0;
            crc_table[130] = 0x80;
            crc_table[131] = 0x41;
            crc_table[132] = 0x0;
            crc_table[133] = 0xC1;
            crc_table[134] = 0x81;
            crc_table[135] = 0x40;
            crc_table[136] = 0x0;
            crc_table[137] = 0xC1;
            crc_table[138] = 0x81;
            crc_table[139] = 0x40;
            crc_table[140] = 0x1;
            crc_table[141] = 0xC0;
            crc_table[142] = 0x80;
            crc_table[143] = 0x41;
            crc_table[144] = 0x0;
            crc_table[145] = 0xC1;
            crc_table[146] = 0x81;
            crc_table[147] = 0x40;
            crc_table[148] = 0x1;
            crc_table[149] = 0xC0;
            crc_table[150] = 0x80;
            crc_table[151] = 0x41;
            crc_table[152] = 0x1;
            crc_table[153] = 0xC0;
            crc_table[154] = 0x80;
            crc_table[155] = 0x41;
            crc_table[156] = 0x0;
            crc_table[157] = 0xC1;
            crc_table[158] = 0x81;
            crc_table[159] = 0x40;
            crc_table[160] = 0x0;
            crc_table[161] = 0xC1;
            crc_table[162] = 0x81;
            crc_table[163] = 0x40;
            crc_table[164] = 0x1;
            crc_table[165] = 0xC0;
            crc_table[166] = 0x80;
            crc_table[167] = 0x41;
            crc_table[168] = 0x1;
            crc_table[169] = 0xC0;
            crc_table[170] = 0x80;
            crc_table[171] = 0x41;
            crc_table[172] = 0x0;
            crc_table[173] = 0xC1;
            crc_table[174] = 0x81;
            crc_table[175] = 0x40;
            crc_table[176] = 0x1;
            crc_table[177] = 0xC0;
            crc_table[178] = 0x80;
            crc_table[179] = 0x41;
            crc_table[180] = 0x0;
            crc_table[181] = 0xC1;
            crc_table[182] = 0x81;
            crc_table[183] = 0x40;
            crc_table[184] = 0x0;
            crc_table[185] = 0xC1;
            crc_table[186] = 0x81;
            crc_table[187] = 0x40;
            crc_table[188] = 0x1;
            crc_table[189] = 0xC0;
            crc_table[190] = 0x80;
            crc_table[191] = 0x41;
            crc_table[192] = 0x0;
            crc_table[193] = 0xC1;
            crc_table[194] = 0x81;
            crc_table[195] = 0x40;
            crc_table[196] = 0x1;
            crc_table[197] = 0xC0;
            crc_table[198] = 0x80;
            crc_table[199] = 0x41;
            crc_table[200] = 0x1;
            crc_table[201] = 0xC0;
            crc_table[202] = 0x80;
            crc_table[203] = 0x41;
            crc_table[204] = 0x0;
            crc_table[205] = 0xC1;
            crc_table[206] = 0x81;
            crc_table[207] = 0x40;
            crc_table[208] = 0x1;
            crc_table[209] = 0xC0;
            crc_table[210] = 0x80;
            crc_table[211] = 0x41;
            crc_table[212] = 0x0;
            crc_table[213] = 0xC1;
            crc_table[214] = 0x81;
            crc_table[215] = 0x40;
            crc_table[216] = 0x0;
            crc_table[217] = 0xC1;
            crc_table[218] = 0x81;
            crc_table[219] = 0x40;
            crc_table[220] = 0x1;
            crc_table[221] = 0xC0;
            crc_table[222] = 0x80;
            crc_table[223] = 0x41;
            crc_table[224] = 0x1;
            crc_table[225] = 0xC0;
            crc_table[226] = 0x80;
            crc_table[227] = 0x41;
            crc_table[228] = 0x0;
            crc_table[229] = 0xC1;
            crc_table[230] = 0x81;
            crc_table[231] = 0x40;
            crc_table[232] = 0x0;
            crc_table[233] = 0xC1;
            crc_table[234] = 0x81;
            crc_table[235] = 0x40;
            crc_table[236] = 0x1;
            crc_table[237] = 0xC0;
            crc_table[238] = 0x80;
            crc_table[239] = 0x41;
            crc_table[240] = 0x0;
            crc_table[241] = 0xC1;
            crc_table[242] = 0x81;
            crc_table[243] = 0x40;
            crc_table[244] = 0x1;
            crc_table[245] = 0xC0;
            crc_table[246] = 0x80;
            crc_table[247] = 0x41;
            crc_table[248] = 0x1;
            crc_table[249] = 0xC0;
            crc_table[250] = 0x80;
            crc_table[251] = 0x41;
            crc_table[252] = 0x0;
            crc_table[253] = 0xC1;
            crc_table[254] = 0x81;
            crc_table[255] = 0x40;
            crc_table[256] = 0x0;
            crc_table[257] = 0xC0;
            crc_table[258] = 0xC1;
            crc_table[259] = 0x1;
            crc_table[260] = 0xC3;
            crc_table[261] = 0x3;
            crc_table[262] = 0x2;
            crc_table[263] = 0xC2;
            crc_table[264] = 0xC6;
            crc_table[265] = 0x6;
            crc_table[266] = 0x7;
            crc_table[267] = 0xC7;
            crc_table[268] = 0x5;
            crc_table[269] = 0xC5;
            crc_table[270] = 0xC4;
            crc_table[271] = 0x4;
            crc_table[272] = 0xCC;
            crc_table[273] = 0xC;
            crc_table[274] = 0xD;
            crc_table[275] = 0xCD;
            crc_table[276] = 0xF;
            crc_table[277] = 0xCF;
            crc_table[278] = 0xCE;
            crc_table[279] = 0xE;
            crc_table[280] = 0xA;
            crc_table[281] = 0xCA;
            crc_table[282] = 0xCB;
            crc_table[283] = 0xB;
            crc_table[284] = 0xC9;
            crc_table[285] = 0x9;
            crc_table[286] = 0x8;
            crc_table[287] = 0xC8;
            crc_table[288] = 0xD8;
            crc_table[289] = 0x18;
            crc_table[290] = 0x19;
            crc_table[291] = 0xD9;
            crc_table[292] = 0x1B;
            crc_table[293] = 0xDB;
            crc_table[294] = 0xDA;
            crc_table[295] = 0x1A;
            crc_table[296] = 0x1E;
            crc_table[297] = 0xDE;
            crc_table[298] = 0xDF;
            crc_table[299] = 0x1F;
            crc_table[300] = 0xDD;
            crc_table[301] = 0x1D;
            crc_table[302] = 0x1C;
            crc_table[303] = 0xDC;
            crc_table[304] = 0x14;
            crc_table[305] = 0xD4;
            crc_table[306] = 0xD5;
            crc_table[307] = 0x15;
            crc_table[308] = 0xD7;
            crc_table[309] = 0x17;
            crc_table[310] = 0x16;
            crc_table[311] = 0xD6;
            crc_table[312] = 0xD2;
            crc_table[313] = 0x12;
            crc_table[314] = 0x13;
            crc_table[315] = 0xD3;
            crc_table[316] = 0x11;
            crc_table[317] = 0xD1;
            crc_table[318] = 0xD0;
            crc_table[319] = 0x10;
            crc_table[320] = 0xF0;
            crc_table[321] = 0x30;
            crc_table[322] = 0x31;
            crc_table[323] = 0xF1;
            crc_table[324] = 0x33;
            crc_table[325] = 0xF3;
            crc_table[326] = 0xF2;
            crc_table[327] = 0x32;
            crc_table[328] = 0x36;
            crc_table[329] = 0xF6;
            crc_table[330] = 0xF7;
            crc_table[331] = 0x37;
            crc_table[332] = 0xF5;
            crc_table[333] = 0x35;
            crc_table[334] = 0x34;
            crc_table[335] = 0xF4;
            crc_table[336] = 0x3C;
            crc_table[337] = 0xFC;
            crc_table[338] = 0xFD;
            crc_table[339] = 0x3D;
            crc_table[340] = 0xFF;
            crc_table[341] = 0x3F;
            crc_table[342] = 0x3E;
            crc_table[343] = 0xFE;
            crc_table[344] = 0xFA;
            crc_table[345] = 0x3A;
            crc_table[346] = 0x3B;
            crc_table[347] = 0xFB;
            crc_table[348] = 0x39;
            crc_table[349] = 0xF9;
            crc_table[350] = 0xF8;
            crc_table[351] = 0x38;
            crc_table[352] = 0x28;
            crc_table[353] = 0xE8;
            crc_table[354] = 0xE9;
            crc_table[355] = 0x29;
            crc_table[356] = 0xEB;
            crc_table[357] = 0x2B;
            crc_table[358] = 0x2A;
            crc_table[359] = 0xEA;
            crc_table[360] = 0xEE;
            crc_table[361] = 0x2E;
            crc_table[362] = 0x2F;
            crc_table[363] = 0xEF;
            crc_table[364] = 0x2D;
            crc_table[365] = 0xED;
            crc_table[366] = 0xEC;
            crc_table[367] = 0x2C;
            crc_table[368] = 0xE4;
            crc_table[369] = 0x24;
            crc_table[370] = 0x25;
            crc_table[371] = 0xE5;
            crc_table[372] = 0x27;
            crc_table[373] = 0xE7;
            crc_table[374] = 0xE6;
            crc_table[375] = 0x26;
            crc_table[376] = 0x22;
            crc_table[377] = 0xE2;
            crc_table[378] = 0xE3;
            crc_table[379] = 0x23;
            crc_table[380] = 0xE1;
            crc_table[381] = 0x21;
            crc_table[382] = 0x20;
            crc_table[383] = 0xE0;
            crc_table[384] = 0xA0;
            crc_table[385] = 0x60;
            crc_table[386] = 0x61;
            crc_table[387] = 0xA1;
            crc_table[388] = 0x63;
            crc_table[389] = 0xA3;
            crc_table[390] = 0xA2;
            crc_table[391] = 0x62;
            crc_table[392] = 0x66;
            crc_table[393] = 0xA6;
            crc_table[394] = 0xA7;
            crc_table[395] = 0x67;
            crc_table[396] = 0xA5;
            crc_table[397] = 0x65;
            crc_table[398] = 0x64;
            crc_table[399] = 0xA4;
            crc_table[400] = 0x6C;
            crc_table[401] = 0xAC;
            crc_table[402] = 0xAD;
            crc_table[403] = 0x6D;
            crc_table[404] = 0xAF;
            crc_table[405] = 0x6F;
            crc_table[406] = 0x6E;
            crc_table[407] = 0xAE;
            crc_table[408] = 0xAA;
            crc_table[409] = 0x6A;
            crc_table[410] = 0x6B;
            crc_table[411] = 0xAB;
            crc_table[412] = 0x69;
            crc_table[413] = 0xA9;
            crc_table[414] = 0xA8;
            crc_table[415] = 0x68;
            crc_table[416] = 0x78;
            crc_table[417] = 0xB8;
            crc_table[418] = 0xB9;
            crc_table[419] = 0x79;
            crc_table[420] = 0xBB;
            crc_table[421] = 0x7B;
            crc_table[422] = 0x7A;
            crc_table[423] = 0xBA;
            crc_table[424] = 0xBE;
            crc_table[425] = 0x7E;
            crc_table[426] = 0x7F;
            crc_table[427] = 0xBF;
            crc_table[428] = 0x7D;
            crc_table[429] = 0xBD;
            crc_table[430] = 0xBC;
            crc_table[431] = 0x7C;
            crc_table[432] = 0xB4;
            crc_table[433] = 0x74;
            crc_table[434] = 0x75;
            crc_table[435] = 0xB5;
            crc_table[436] = 0x77;
            crc_table[437] = 0xB7;
            crc_table[438] = 0xB6;
            crc_table[439] = 0x76;
            crc_table[440] = 0x72;
            crc_table[441] = 0xB2;
            crc_table[442] = 0xB3;
            crc_table[443] = 0x73;
            crc_table[444] = 0xB1;
            crc_table[445] = 0x71;
            crc_table[446] = 0x70;
            crc_table[447] = 0xB0;
            crc_table[448] = 0x50;
            crc_table[449] = 0x90;
            crc_table[450] = 0x91;
            crc_table[451] = 0x51;
            crc_table[452] = 0x93;
            crc_table[453] = 0x53;
            crc_table[454] = 0x52;
            crc_table[455] = 0x92;
            crc_table[456] = 0x96;
            crc_table[457] = 0x56;
            crc_table[458] = 0x57;
            crc_table[459] = 0x97;
            crc_table[460] = 0x55;
            crc_table[461] = 0x95;
            crc_table[462] = 0x94;
            crc_table[463] = 0x54;
            crc_table[464] = 0x9C;
            crc_table[465] = 0x5C;
            crc_table[466] = 0x5D;
            crc_table[467] = 0x9D;
            crc_table[468] = 0x5F;
            crc_table[469] = 0x9F;
            crc_table[470] = 0x9E;
            crc_table[471] = 0x5E;
            crc_table[472] = 0x5A;
            crc_table[473] = 0x9A;
            crc_table[474] = 0x9B;
            crc_table[475] = 0x5B;
            crc_table[476] = 0x99;
            crc_table[477] = 0x59;
            crc_table[478] = 0x58;
            crc_table[479] = 0x98;
            crc_table[480] = 0x88;
            crc_table[481] = 0x48;
            crc_table[482] = 0x49;
            crc_table[483] = 0x89;
            crc_table[484] = 0x4B;
            crc_table[485] = 0x8B;
            crc_table[486] = 0x8A;
            crc_table[487] = 0x4A;
            crc_table[488] = 0x4E;
            crc_table[489] = 0x8E;
            crc_table[490] = 0x8F;
            crc_table[491] = 0x4F;
            crc_table[492] = 0x8D;
            crc_table[493] = 0x4D;
            crc_table[494] = 0x4C;
            crc_table[495] = 0x8C;
            crc_table[496] = 0x44;
            crc_table[497] = 0x84;
            crc_table[498] = 0x85;
            crc_table[499] = 0x45;
            crc_table[500] = 0x87;
            crc_table[501] = 0x47;
            crc_table[502] = 0x46;
            crc_table[503] = 0x86;
            crc_table[504] = 0x82;
            crc_table[505] = 0x42;
            crc_table[506] = 0x43;
            crc_table[507] = 0x83;
            crc_table[508] = 0x41;
            crc_table[509] = 0x81;
            crc_table[510] = 0x80;
            crc_table[511] = 0x40;
            #endregion
            if (configuration == null || configuration.DataList == null)
                return;
            DataList = configuration.DataList;
            Setting = configuration.ComSetting;
            SlaveID = configuration.SlaveID;
            #region 填充数据集合
            DicData = new Dictionary<short, short>();
            foreach (RecivedData data in DataList)
            {
                DicData.Add(data.Address, 0);
            }
            #endregion

        }
        #endregion

        /// <summary>
        /// websocket服务，因为一开始就需要打开，在一开始打开
        /// </summary>

        #region 打开、关闭COM口
        /// <summary>
        /// 打开COM口
        /// </summary>
        /// <param name="portName">COM口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="stopBits">停止位</param>
        /// <returns></returns>
        public void Start()
        {
            Task.Run(async () => { await mqttclient.ConnectMqttServerAsync(); });
            if (!sp.IsOpen)
            {
                try
                {
                    sp.PortName = Setting.PortName;
                    sp.BaudRate = Setting.BaudRate;
                    sp.DataBits = Setting.DataBits;
                    sp.Parity = Setting.Parity;
                    sp.StopBits = Setting.StopBits;
                    sp.DtrEnable = true;//启用控制终端就续信号
                    sp.RtsEnable = true; //启用请求发送信号
                    sp.ReadTimeout = 1000;
                    sp.WriteTimeout = 1000;
                    sp.Open();
                    Status = AppStatus.监听;
                    //发送数据请求
                    byte[] crcBytes = new byte[2];
                    byte[] sendResponse = new byte[6 + crcBytes.Length];
                    sendResponse[0] = 0x01;
                    sendResponse[1] = 0x03;
                    sendResponse[2] = 0x00;
                    sendResponse[3] = 0x00;
                    sendResponse[4] = 0x00;
                    sendResponse[5] = 0x07;
                    GetCRC(sendResponse, ref crcBytes);
                    sendResponse[sendResponse.Length - 1] = crcBytes[1];//高8位   
                    sendResponse[sendResponse.Length - 2] = crcBytes[0];//低8位

                    sp.Write(sendResponse, 0, sendResponse.Length);
                    sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                }
                catch (Exception e)
                {
                    Status = AppStatus.停止;
                    Console.Write(e.ToString());
                }
            }

        }

        /// <summary>
        /// 关闭COM口
        /// </summary>
        /// <returns></returns>
        public void Close()
        {
            if (sp != null)
            {
                if (sp.IsOpen)
                {
                    try
                    {
                        sp.Close();
                    }
                    catch
                    {
                    }
                }
            }
            Status = AppStatus.停止;
        }
        /// <summary>
        /// 刷新指定数据
        /// </summary>
        public void RefreshData(short address, float value)
        {
            foreach (RecivedData data in DataList)
            {
                if (data.Address == address)
                {
                    DicData[address] = (short)(value * (data.ExactNum == 0 ? 1 : data.ExactNum));
                    break;
                }
            }
        }
        #endregion
        #region 生成CRC码
        /// <summary>
        /// 生成CRC码
        /// </summary>
        /// <param name="message">发送或返回的命令，CRC码除外</param>
        /// <param name="CRC">生成的CRC码</param>
        public void GetCRC(byte[] message, ref byte[] CRC)
        {
            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;
            for (int i = 0; i < message.Length - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ message[i]);
                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    //下面两句所得结果一样
                    //CRCFull = (ushort)(CRCFull >> 1);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);
                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
        }
        #endregion
        #region CRC验证
        /// <summary>
        /// 国标算法
        /// </summary>
        /// <param name="modbusframe">数据</param>
        /// <param name="Length">数据字节长度</param>
        /// <returns></returns>
        private int crc16(byte[] modbusframe, int Length)
        {
            int i;
            int index;
            int crc_Low = 0xFF;
            int crc_High = 0xFF;

            for (i = 0; i < Length; i++)
            {
                index = crc_High ^ (char)modbusframe[i];
                crc_High = crc_Low ^ crc_table[index];
                crc_Low = (byte)crc_table[index + 256];
            }

            return crc_High * 256 + crc_Low;
        }
        /// <summary>
        /// CRC校验
        /// </summary>
        /// <param name="src">ST开头，&&结尾</param>
        /// <returns>十六进制数</returns>
        public string CRCEfficacy(string src)
        {
            byte[] byteArr = Encoding.UTF8.GetBytes(src);
            int len = byteArr.Length;
            int temp = crc16(byteArr, len);
            string result = temp.ToString("X");
            return result;
        }
        #endregion
        #region 数据读取
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (o)
            {
                try
                {
                    Thread.Sleep(global.CycleTime);
                    //发送数据请求

                    byte[] crcBytes = new byte[2];
                    byte[] sendResponse = new byte[6 + crcBytes.Length];
                    sendResponse[0] = 0x01;
                    sendResponse[1] = 0x03;
                    sendResponse[2] = 0x00;
                    sendResponse[3] = 0x00;
                    sendResponse[4] = 0x00;
                    sendResponse[5] = 0x07;
                    GetCRC(sendResponse, ref crcBytes);
                    sendResponse[sendResponse.Length - 1] = crcBytes[1];//高8位   
                    sendResponse[sendResponse.Length - 2] = crcBytes[0];//低8位
                    sp.Write(sendResponse, 0, sendResponse.Length);
                    int len = sp.BytesToRead;
                    if (len != 0)
                    {
                        byte[] buff = new byte[len];
                        sp.Read(buff, 0, len);
                        Thread thread = new Thread(new ParameterizedThreadStart(HandData));
                        thread.Start(buff);
                    }
                }
                catch (Exception ex)
                {
                    DeBugMessage(ex.Message);
                }
            }
        }
        /// <summary>
        /// 数据接收线程
        /// </summary> 
        private void HandData(object o)
        {
            byte[] buff = o as byte[];
            if (buff == null)
                return;
            if (buff.Length < 8)
                return;
            ModbusData data = new ModbusData();
            int num = 0;
            data.SlaveID = buff[num];
            while (data.SlaveID != SlaveID)
            {
                ++num;
                data.SlaveID = buff[num];
            }
            if (data.SlaveID != SlaveID)//判断是否符合从机地址
            {
                ErrorMessage(Convert.ToInt32("2DF", 16).ToString());
                ErrorMessage("从机地址错误，地址:" + data.SlaveID);
                //Console.WriteLine(Convert.ToInt32("2DF",16));
                return;
            }

            int crc = crc16(buff, num + 19);
            if (crc != 0)
            {
                //Crc数据校验失败 
                string str = string.Empty;
                foreach (byte b in buff)
                {
                    str += b + " ";
                }
                ErrorMessage("Crc校验错误，数据:" + str);
            }

            data.Code = buff[num + 1];
            var valueLength = buff[num + 2];
            if (data.Code == 3 && valueLength == 14)
            {
                string str = string.Empty;
                foreach (byte b in buff)
                {
                    str += b + " ";
                }
                // double Dwind = buff[6];
                //double Swind = GetData(buff, 7);
                //double temperature = GetData(buff, 11);
                //double humidity = GetData(buff, 15);
                //double Airpressure = GetData(buff, 19) / 10;
                //double IRainfall = GetData(buff, 27);
                //double URainfall = buff[36];
                //double PM25 = GetData(buff, 53);
                //double DailyDose = GetData(buff, 65);
                //double SunPower = GetData(buff, 69);

                double temperature = GetData(buff, num + 3) / 10;//温度
                double humidity = GetData(buff, num + 5) / 10;//湿度
                double Airpressure = GetData(buff, num + 7) / 10;//气压
                double Swind = GetData(buff, num + 9) / 10;//风速
                double Dwind = GetData(buff, num + 11); //风向1
                double Dwind2 = GetData(buff, num + 13);//风向2
                double IRainfall = GetData(buff, num + 15) / 10;//雨量

                string sqldata = temperature + "," + humidity + "," + Airpressure + "," + Swind + "," + Dwind + "," + GetDWind(Dwind2) + "," + IRainfall;
                //MySqlHelp mysql = new MySqlHelp();

                //string sqldata = GetDWind(Dwind) + "," + Swind + "," + temperature + "," + humidity + "," + Airpressure + "," + PM25 + "," + DailyDose + "," + SunPower + ",";
                // handleData(sqldata);
                string result = string.Format("风向:{0}，风速：{1} ，温度：{2}，湿度：{3}，气压：{4}，降雨强度：{5}", GetDWind(Dwind) + " " + Dwind, Swind, temperature, humidity, Airpressure, IRainfall);
                List<object> values = new List<object>();
                values.Add(temperature);
                values.Add(humidity);
                values.Add(Airpressure);
                values.Add(Swind);
                values.Add(Dwind);
                values.Add(GetDWind(Dwind2));
                values.Add(IRainfall);
                string topic = ConfigurationManager.AppSettings["topic"];
                try
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string json = js.Serialize(values);
                    Task.Run(async () => { await mqttclient.Publish(topic, json); });
                }
                catch(Exception ex)
                {
                    ErrorMessage(ex.Message);
                }
                InfoMessage(result);
            }
            else
            {
                //其他命令数据 
                string str = string.Empty;
                foreach (byte b in buff)
                {
                    str += b + " ";
                }
                InfoMessage("其他命令数据，数据:" + str);
            }
        }
        /// <summary>
        /// 通知消息至前端
        /// </summary>  

        private void ErrorMessage(string message)
        {

            LogMessage logMessage = new LogMessage
            {
                OperationTime = DateTime.Now,
                Class = typeof(Program).ToString(),
                Content = message
            };
            logger.Error(new LogFormat().ErrorFormat(logMessage));
            Console.WriteLine(DateTime.Now + message);
        }
        private void DeBugMessage(string message)
        {

            LogMessage logMessage = new LogMessage
            {
                OperationTime = DateTime.Now,
                Class = typeof(Program).ToString(),
                Content = message
            };
            logger.Debug(new LogFormat().DebugFormat(logMessage));
            Console.WriteLine(DateTime.Now + message);
        }
        private void InfoMessage(string message)
        {

            LogMessage logMessage = new LogMessage
            {
                OperationTime = DateTime.Now,
                Class = typeof(Program).ToString(),
                Content = message
            };
            logger.Info(new LogFormat().InfoFormat(logMessage));
            Console.WriteLine(DateTime.Now + message);
        }

        #endregion
        #region 数据处理
        //private void handleData(string data)
        //{
        //    SL_LIGHT_dal Light_dal = new SL_LIGHT_dal();
        //    SL_LIGHT lightmodel = new SL_LIGHT();
        //    SqlHelper.ExcuteSql(global.sqlserver, (c) =>
        //    {
        //        lightmodel = Light_dal.Get(c, "6");
        //    });
        //    if (lightmodel != null)
        //    {
        //        lightmodel.APID = data;
        //        SL_LIGHT_dal SL_Light_dal = new SL_LIGHT_dal();
        //        SqlHelper.ExcuteSql(global.sqlserver, (c) =>
        //        {
        //            lightmodel.ModifyDate = DateTime.Now;
        //            SL_Light_dal.Update(c, lightmodel);
        //        });
        //    }
        //}
        #endregion
        //private static double GetData(byte[] buff, int startindex)
        //{
        //    string aa = CommonHelper.Ten2Hex(buff[12]);
        //    byte[] bytes = new byte[4];
        //    bytes[0] = buff[startindex + 1];
        //    bytes[1] = buff[startindex];
        //    bytes[2] = buff[startindex + 3];
        //    bytes[3] = buff[startindex + 2];
        //    double fa = BitConverter.ToSingle(bytes, 0);
        //    double fa2 = Math.Round(fa, 2, MidpointRounding.AwayFromZero);
        //    return fa2;
        //}

        public static String c10_c16(int num)
        {
            String result = "";
            for (int i = 1; i < num; i *= 16)
            {
                int temp = num / (i) % 16;
                String t = "";
                switch (temp)
                {
                    case 10:
                        t = "A";
                        break;
                    case 11:
                        t = "B";
                        break;
                    case 12:
                        t = "C";
                        break;
                    case 13:
                        t = "D";
                        break;
                    case 14:
                        t = "E";
                        break;
                    case 15:
                        t = "F";
                        break;
                    default:
                        t = temp + "";
                        break;
                }
                result = t + result;
            }
            if (num == 0)
            {
                result = "0";
            }
            else if (num == 1)
            {
                result = "1";
            }
            return result;
        }
        private static double GetData(byte[] buff, int startindex)
        {
            byte[] bytes = new byte[2];
            bytes[0] = buff[startindex];
            bytes[1] = buff[startindex + 1];

            int num = bytes[0];
            string numble = c10_c16(num);
            int num1 = bytes[1];
            string numble2 = c10_c16(num1);
            double value = 0;
            value = Convert.ToInt32((numble + numble2), 16);

            return value;
        }
        private static string GetDWind(double Angle)
        {
            string strDWind = "";
            if (Angle <= 22.5 || Angle >= 337.6)
            {
                strDWind = "北风";
            }
            else if (Angle >= 22.6 && Angle <= 67.5)
            {
                strDWind = "东北风";
            }
            else if (Angle >= 67.6 && Angle <= 112.5)
            {
                strDWind = "东风";
            }
            else if (Angle >= 112.6 && Angle <= 157.5)
            {
                strDWind = "东南风";
            }
            else if (Angle >= 157.6 && Angle <= 202.5)
            {
                strDWind = "南风";
            }
            else if (Angle >= 202.6 && Angle <= 247.5)
            {
                strDWind = "西南风";
            }
            else if (Angle >= 247.6 && Angle <= 292.5)
            {
                strDWind = "西风";
            }
            else if (Angle >= 292.6 && Angle <= 337.5)
            {
                strDWind = "西北风";
            }
            else
            {
            }
            return strDWind;
        }
        private static double GetRainful(double IRainfall, double URainfall)
        {
            double data = 0;
            if (URainfall == 0)
            {
                data = IRainfall / 60;
            }
            else if (URainfall == 1)
            {
                data = IRainfall;
            }
            else if (URainfall == 2)
            {
                data = IRainfall * 60;
            }
            return data;
        }
    }


    /// <summary>
    /// 接收到的数据信息
    /// </summary>
    public class ModbusData
    {
        /// <summary>
        /// 从机地址
        /// </summary>
        public byte SlaveID { get; set; }
        /// <summary>
        /// 功能码
        /// </summary>
        public byte Code { get; set; }
        /// <summary>
        /// 数据开始地址
        /// </summary>
        public Int16 StartAddress { get; set; }
        /// <summary>
        /// 寄存器个数
        /// </summary>
        public Int16 MCount { get; set; }
        /// <summary>
        /// 数值值列表
        /// </summary>
        public Int16[] Data { get; set; }
    }
}