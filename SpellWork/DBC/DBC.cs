using System.Collections.Generic;

namespace SpellWork
{
    public static class DBC
    {
        public const string VERSION  = "SpellWork 2.4.3 (8606)";
        public const string DBC_PATH = @"dbc\";

        public const int MAX_DBC_LOCALE                 = 16;
        public const int MAX_EFFECT_INDEX               = 3;
        public const int SPELL_ENTRY_FOR_DETECT_LOCALE  = 1;

        public static Dictionary<uint, SpellEntry>                  Spell;
        public static Dictionary<uint, SpellRadiusEntry>            SpellRadius;
        public static Dictionary<uint, SpellCastTimesEntry>         SpellCastTimes;
        public static Dictionary<uint, SpellRangeEntry>             SpellRange;
        public static Dictionary<uint, SpellDurationEntry>          SpellDuration;
        public static Dictionary<uint, SkillLineAbilityEntry>       SkillLineAbility;
        public static Dictionary<uint, SkillLineEntry>              SkillLine;

        public static Dictionary<uint, string> SpellStrings            = new Dictionary<uint, string>();
        public static Dictionary<uint, string> SkillLineStrings        = new Dictionary<uint, string>();
        public static Dictionary<uint, string> SpellRangeStrings       = new Dictionary<uint, string>();

        // DB 
        public static List<Item> ItemTemplate = new List<Item>();

        // Locale
        public static LocalesDBC Locale { get; set; }
    }
}
