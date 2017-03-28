using System;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SpellWork
{
    public struct DbcHeader
    {
        public int Signature;
        public int RecordsCount;
        public int FieldsCount;
        public int RecordSize;
        public int StringTableSize;
        
        public bool IsDBC
        {
            get { return Signature == 0x43424457; }
        }
        
        public long DataSize
        {
            get { return (long)(RecordsCount * RecordSize); }
        }

        public long StartStringPosition
        {
            get { return DataSize + (long)Marshal.SizeOf(typeof(DbcHeader)); }
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellEntry
    {
        public uint ID;                                           // 0        m_ID
        public uint Category;                                     // 1        m_category
        public uint CastUI;                                       // 2        not used
		public uint Dispel;                                       // 3        m_dispelType
        public uint Mechanic;                                     // 4        m_mechanic
        public uint Attributes;                                   // 5        m_attribute
        public uint AttributesEx;                                 // 6        m_attributesEx
        public uint AttributesEx2;                                // 7        m_attributesExB
        public uint AttributesEx3;                                // 8        m_attributesExC
        public uint AttributesEx4;                                // 9        m_attributesExD
        public uint AttributesEx5;                                // 10       m_attributesExE
        public uint AttributesEx6;                                // 11       m_attributesExF
        public uint Stances;                                      // 12       m_shapeshiftMask
        public uint StancesNot;                                   // 13       m_shapeshiftExclude
        public uint Targets;                                      // 14       m_targets
        public uint TargetCreatureType;                           // 15       m_targetCreatureType
        public uint RequiresSpellFocus;                           // 16       m_requiresSpellFocus
        public uint FacingCasterFlags;                            // 17       m_facingCasterFlags
        public uint CasterAuraState;                              // 18       m_casterAuraState
        public uint TargetAuraState;                              // 19       m_targetAuraState
        public uint CasterAuraStateNot;                           // 20       m_excludeCasterAuraState
        public uint TargetAuraStateNot;                           // 21       m_excludeTargetAuraState
        public uint CastingTimeIndex;                             // 22       m_castingTimeIndex
        public uint RecoveryTime;                                 // 23       m_recoveryTime
        public uint CategoryRecoveryTime;                         // 24       m_categoryRecoveryTime
        public uint InterruptFlags;                               // 25       m_interruptFlags
        public uint AuraInterruptFlags;                           // 26       m_auraInterruptFlags
        public uint ChannelInterruptFlags;                        // 27       m_channelInterruptFlags
        public uint ProcFlags;                                    // 28       m_procTypeMask
        public uint ProcChance;                                   // 29       m_procChance
        public uint ProcCharges;                                  // 30       m_procCharges
        public uint MaxLevel;                                     // 31       m_maxLevel
        public uint BaseLevel;                                    // 32       m_baseLevel
        public uint SpellLevel;                                   // 33       m_spellLevel
        public uint DurationIndex;                                // 34       m_durationIndex
        public uint PowerType;                                    // 35       m_powerType
        public uint ManaCost;                                     // 36       m_manaCost
        public uint ManaCostPerlevel;                             // 37       m_manaCostPerLevel
        public uint ManaPerSecond;                                // 38       m_manaPerSecond
        public uint ManaPerSecondPerLevel;                        // 39       m_manaPerSecondPerLevel
        public uint RangeIndex;                                   // 40       m_rangeIndex
        public float Speed;                                       // 41       m_speed
        public uint ModalNextSpell;                               // 42       m_modalNextSpell not used
        public uint StackAmount;                                  // 43       m_cumulativeAura
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Totem;                                      // 50-51    m_totem
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public int[] Reagent;                                     // 52-59    m_reagent
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] ReagentCount;                               // 60-67    m_reagentCount
        public int EquippedItemClass;                             // 68       m_equippedItemClass (value)
        public int EquippedItemSubClassMask;                      // 69       m_equippedItemSubclass (mask)
        public int EquippedItemInventoryTypeMask;                 // 70       m_equippedItemInvTypes (mask)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] Effect;                     				  // 71-73    m_effect
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public int[] EffectDieSides;                              // 74-76    m_effectDieSides
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectBaseDice; 
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public float[] EffectDicePerLevel;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public float[] EffectRealPointsPerLevel;                  // 77-79    m_effectRealPointsPerLevel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public int[] EffectBasePoints;                            // 80-82    m_effectBasePoints (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectMechanic;                             // 83-85    m_effectMechanic
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectImplicitTargetA;                      // 86-88    m_implicitTargetA
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectImplicitTargetB;                      // 89-91    m_implicitTargetB
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectRadiusIndex;                          // 92-94    m_effectRadiusIndex - spellradius.dbc
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectApplyAuraName;                        // 95-97    m_effectAura
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectAmplitude;                            // 98-100   m_effectAuraPeriod
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public float[] EffectMultipleValue;                       // 101-103  m_effectAmplitude
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectChainTarget;                          // 104-106  m_effectChainTargets
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectItemType;                             // 107-109  m_effectItemType
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public int[] EffectMiscValue;                             // 110-112  m_effectMiscValue
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public int[] EffectMiscValueB;                            // 113-115  m_effectMiscValueB
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectTriggerSpell;                         // 116-118  m_effectTriggerSpell
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public float[] EffectPointsPerComboPoint;                 // 119-121  m_effectPointsPerCombo
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] SpellVisual;                                // 131-132  m_spellVisualID
        public uint SpellIconID;                                  // 133      m_spellIconID
        public uint ActiveIconID;                                 // 134      m_activeIconID
        public uint SpellPriority;                                // 135      m_spellPriority not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        private uint[] _SpellName;                                // 136-151  m_name_lang
        public uint SpellNameFlag;                                // 152      not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        private uint[] _Rank;                                     // 153-168  m_nameSubtext_lang
        public uint RankFlags;                                    // 169      not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        private uint[] _Description;                              // 170-185  m_description_lang not used
        public uint DescriptionFlags;                             // 186      not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        private uint[] _ToolTip;                                  // 187-202  m_auraDescription_lang not used
        public uint ToolTipFlags;                                 // 203      not used
        public uint ManaCostPercentage;                           // 204      m_manaCostPct
        public uint StartRecoveryCategory;                        // 205      m_startRecoveryCategory
        public uint StartRecoveryTime;                            // 206      m_startRecoveryTime
        public uint MaxTargetLevel;                               // 207      m_maxTargetLevel
        public uint SpellFamilyName;                              // 208      m_spellClassSet
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] SpellFamilyFlags;                             // 209-211  m_spellClassMask NOTE: size is 12 bytes!!!
        public uint MaxAffectedTargets;                           // 212      m_maxTargets
        public uint DmgClass;                                     // 213      m_defenseType
        public uint PreventionType;                               // 214      m_preventionType
        public uint StanceBarOrder;                               // 215      m_stanceBarOrder not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] DmgMultiplier;              				  // 216-218  m_effectChainAmplitude
        public uint MinFactionId;                                 // 219      m_minFactionID not used
        public uint MinReputation;                                // 220      m_minReputation not used
        public uint RequiredAuraVision;                           // 221      m_requiredAuraVision not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] TotemCategory;                              // 222-223  m_requiredTotemCategoryID
        public int  AreaGroupId;                                  // 224      m_requiredAreaGroupId
        public uint SchoolMask;                                   // 225      m_schoolMask

        /// <summary>
        /// Return current Spell Name
        /// </summary>
        public string SpellName
        {
            get { return DBC.SpellStrings.GetValue(_SpellName[(uint)DBC.Locale]); }
        }

        /// <summary>
        /// Return current Spell Rank
        /// </summary>
        public string Rank
        {
            get { return _Rank[(uint)DBC.Locale] != 0 ? DBC.SpellStrings[_Rank[(uint)DBC.Locale]] : ""; }
        }

        public string SpellNameRank
        {
            get { return Rank.IsEmpty() ? SpellName : String.Format("{0} ({1})", SpellName, Rank); }
        }

        /// <summary>
        /// Return current Spell Description
        /// </summary>
        public string Description
        {
            get { return DBC.SpellStrings.GetValue(_Description[(uint)DBC.Locale]); }
        }

        /// <summary>
        /// Return current Spell ToolTip
        /// </summary>
        public string ToolTip
        {
            get { return DBC.SpellStrings.GetValue(_ToolTip[(uint)DBC.Locale]); }
        }

        public string GetName(byte loc)
        {
            return DBC.SpellStrings.GetValue(_SpellName[loc]);
        }

        public string ProcInfo
        {
            get
            {
                int i = 0;
                StringBuilder sb = new StringBuilder();
                uint proc = ProcFlags;
                while (proc != 0)
                {
                    if ((proc & 1) != 0)
                        sb.AppendFormatLine("  {0}", SpellEnums.ProcFlagDesc[i]);
                    i++;
                    proc >>= 1;
                }
                return sb.ToString();
            }
        }

        public string Duration
        {
            get { return DBC.SpellDuration.ContainsKey(DurationIndex) ? DBC.SpellDuration[DurationIndex].ToString() : String.Empty; }
        }

        public string Range
        {
            get
            {
                if (RangeIndex == 0 || !DBC.SpellRange.ContainsKey(RangeIndex))
                    return String.Empty;

                SpellRangeEntry range = DBC.SpellRange[RangeIndex];
                StringBuilder sb = new StringBuilder();
                sb.AppendFormatLine("SpellRange: (Id {0}) \"{1}\":", range.ID, range.Description1);
                sb.AppendFormatLine("    MinRange = {0}", range.MinRange);
                sb.AppendFormatLine("    MaxRange = {0}", range.MaxRange);

                return sb.ToString();
            }
        }

        public string GetRadius(int index)
        {
            uint rIndex = EffectRadiusIndex[index];
            if (rIndex != 0)
            {
                if (DBC.SpellRadius.ContainsKey(rIndex))
                    return String.Format("Radius (Id {0}) {1:F}", rIndex, DBC.SpellRadius[rIndex].Radius);
                else
                    return String.Format("Radius (Id {0}) Not found", rIndex);
            }
            return String.Empty;
        }

        public string CastTime
        {
            get
            {
                if (CastingTimeIndex == 0)
                    return String.Empty;

                if (!DBC.SpellCastTimes.ContainsKey(CastingTimeIndex))
                    return String.Format("CastingTime (Id {0}) = ????", CastingTimeIndex);
                else
                    return String.Format("CastingTime (Id {0}) = {1:F}", 
                        CastingTimeIndex, DBC.SpellCastTimes[CastingTimeIndex].CastTime / 1000.0f);
            }
        }

        public SpellSchoolMask School
        {
            get
            {
                return (SpellSchoolMask)SchoolMask;
            }
        }
    };

    public struct SkillLineEntry
    {
        public uint ID;                                            // 0        m_ID
        public int  CategoryId;                                    // 1        m_categoryID
        public uint SkillCostID;                                   // 2        m_skillCostsID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] _Name;                                       // 3-18     m_displayName_lang
        public uint NameFlags;                                     // 19
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] _Description;                                // 20-35    m_description_lang
        public uint DescriptionFlags;                              // 36
        public uint SpellIcon;                                     // 37       m_spellIconID

        public string Name
        {
            get { return DBC.SkillLineStrings.GetValue(_Name[(uint)DBC.Locale]); }
        }

        public string Description
        {
            get { return DBC.SkillLineStrings.GetValue(_Description[(uint)DBC.Locale]); }
        }
    };

    public struct SkillLineAbilityEntry
    {
        public uint ID;                                             // 0        m_ID
        public uint SkillId;                                        // 1        m_skillLine
        public uint SpellId;                                        // 2        m_spell
        public uint Racemask;                                       // 3        m_raceMask
        public uint Classmask;                                      // 4        m_classMask
        public uint RacemaskNot;                                    // 5        m_excludeRace
        public uint ClassmaskNot;                                   // 6        m_excludeClass
        public uint Req_skill_value;                                // 7        m_minSkillLineRank
        public uint Forward_spellid;                                // 8        m_supercededBySpell
        public uint LearnOnGetSkill;                                // 9        m_acquireMethod
        public uint Max_value;                                      // 10       m_trivialSkillLineRankHigh
        public uint Min_value;                                      // 11       m_trivialSkillLineRankLow
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] CharacterPoints;                              // 12-13    m_characterPoints[2]
        public uint ReqTrainpoints;                                 // 14
    };

    public struct SpellRadiusEntry
    {
        public uint  ID;
        public float Radius;
        public int   Zero;
        public float Radius2;
    };

    public struct SpellRangeEntry
    {
        public uint  ID;
        public float MinRange;
        public float MaxRange;
        public uint Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] _Desc1;
        public uint  Desc1Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] _Desc2;
        public uint  Desc2Flags;

        public string Description1
        {
            get { return DBC.SpellRangeStrings.GetValue(_Desc1[(uint)DBC.Locale]); }
        }

        public string Description2
        {
            get { return DBC.SpellRangeStrings.GetValue(_Desc2[(uint)DBC.Locale]); }
        }
    };

    public struct SpellDurationEntry
    {
        public uint ID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Duration;

        public override string ToString()
        {
            return String.Format("Duration: ID ({0})  {1}, {2}, {3}", ID, Duration[0], Duration[1], Duration[2]);
        }
    };

    public struct SpellCastTimesEntry
    {
        public uint  ID;
        public int   CastTime;   
        public float CastTimePerLevel;
        public int   MinCastTime;
    };

    //=============== DateBase =================\\

    public struct SpellProcEventEntry
    {
        public uint     ID;
        public string   SpellName;
        public uint     SchoolMask;
        public uint     SpellFamilyName;
        public uint[]   SpellFamilyMask;
        public uint     ProcFlags;
        public uint     ProcEx;
        public float    PpmRate;
        public float    CustomChance;
        public uint     Cooldown;

        public string[] ToArray()
        {  
            return new[]
            {
                ID.ToString(), 
                SpellName, 
                SchoolMask.ToString(), 
                SpellFamilyName.ToString(), 
                SpellFamilyMask[0].ToString(), 
                SpellFamilyMask[1].ToString(), 
                SpellFamilyMask[2].ToString(), 
                ProcFlags.ToString(), 
                ProcEx.ToString(), 
                PpmRate.ToString(), 
                CustomChance.ToString(), 
                Cooldown.ToString()
            };
        }
    };

    public struct SpellChain
    {
        public int ID;
        public int PrevSpell;
        public int FirstSpell;
        public int Rank;
        public int ReqSpell;
    };

    public struct Item
    {
        public uint     Entry;
        public string   Name;
        public string   Description;
        public string   LocalesName;
        public string   LocalesDescription;
        public uint[]   SpellID;
    };
}
