using NWN.Core;

namespace NWN.API.Constants
{
  public enum PackageType
  {
    Barbarian = NWScript.PACKAGE_BARBARIAN,
    Bard = NWScript.PACKAGE_BARD,
    Cleric = NWScript.PACKAGE_CLERIC,
    Druid = NWScript.PACKAGE_DRUID,
    Fighter = NWScript.PACKAGE_FIGHTER,
    Monk = NWScript.PACKAGE_MONK,
    Paladin = NWScript.PACKAGE_PALADIN,
    Ranger = NWScript.PACKAGE_RANGER,
    Rogue = NWScript.PACKAGE_ROGUE,
    Sorcerer = NWScript.PACKAGE_SORCERER,
    WizardGeneralist = NWScript.PACKAGE_WIZARDGENERALIST,
    DruidInterloper = NWScript.PACKAGE_DRUID_INTERLOPER,
    DruidGray = NWScript.PACKAGE_DRUID_GRAY,
    DruidDeath = NWScript.PACKAGE_DRUID_DEATH,
    DruidHawkmaster = NWScript.PACKAGE_DRUID_HAWKMASTER,
    BarbarianBrute = NWScript.PACKAGE_BARBARIAN_BRUTE,
    BarbarianSlayer = NWScript.PACKAGE_BARBARIAN_SLAYER,
    BarbarianSavage = NWScript.PACKAGE_BARBARIAN_SAVAGE,
    BarbarianOrcBlood = NWScript.PACKAGE_BARBARIAN_ORCBLOOD,
    ClericShaman = NWScript.PACKAGE_CLERIC_SHAMAN,
    ClericDeadWalker = NWScript.PACKAGE_CLERIC_DEADWALKER,
    ClericElementalist = NWScript.PACKAGE_CLERIC_ELEMENTALIST,
    ClericBattlePriest = NWScript.PACKAGE_CLERIC_BATTLE_PRIEST,
    FighterFinesse = NWScript.PACKAGE_FIGHTER_FINESSE,
    FighterPirate = NWScript.PACKAGE_FIGHTER_PIRATE,
    FighterGladiator = NWScript.PACKAGE_FIGHTER_GLADIATOR,
    FighterCommander = NWScript.PACKAGE_FIGHTER_COMMANDER,
    WizardAbjuration = NWScript.PACKAGE_WIZARD_ABJURATION,
    WizardConjuration = NWScript.PACKAGE_WIZARD_CONJURATION,
    WizardDivination = NWScript.PACKAGE_WIZARD_DIVINATION,
    WizardEnchantment = NWScript.PACKAGE_WIZARD_ENCHANTMENT,
    WizardEvocation = NWScript.PACKAGE_WIZARD_EVOCATION,
    WizardIllusion = NWScript.PACKAGE_WIZARD_ILLUSION,
    WizardNecromancy = NWScript.PACKAGE_WIZARD_NECROMANCY,
    WizardTransmutation = NWScript.PACKAGE_WIZARD_TRANSMUTATION,
    SorcererAbjuration = NWScript.PACKAGE_SORCERER_ABJURATION,
    SorcererConjuration = NWScript.PACKAGE_SORCERER_CONJURATION,
    SorcererDivination = NWScript.PACKAGE_SORCERER_DIVINATION,
    SorcererEnchantment = NWScript.PACKAGE_SORCERER_ENCHANTMENT,
    SorcererEvocation = NWScript.PACKAGE_SORCERER_EVOCATION,
    SorcererIllusion = NWScript.PACKAGE_SORCERER_ILLUSION,
    SorcererNecromancy = NWScript.PACKAGE_SORCERER_NECROMANCY,
    SorcererTransmutation = NWScript.PACKAGE_SORCERER_TRANSMUTATION,
    BardBlade = NWScript.PACKAGE_BARD_BLADE,
    BardGallant = NWScript.PACKAGE_BARD_GALLANT,
    BardJester = NWScript.PACKAGE_BARD_JESTER,
    BardLoremaster = NWScript.PACKAGE_BARD_LOREMASTER,
    MonkSpirit = NWScript.PACKAGE_MONK_SPIRIT,
    MonkGifted = NWScript.PACKAGE_MONK_GIFTED,
    MonkDevout = NWScript.PACKAGE_MONK_DEVOUT,
    MonkPeasant = NWScript.PACKAGE_MONK_PEASANT,
    PaladinErrant = NWScript.PACKAGE_PALADIN_ERRANT,
    PaladinUndead = NWScript.PACKAGE_PALADIN_UNDEAD,
    PaladinInquisitor = NWScript.PACKAGE_PALADIN_INQUISITOR,
    PaladinChampion = NWScript.PACKAGE_PALADIN_CHAMPION,
    RangerMarksman = NWScript.PACKAGE_RANGER_MARKSMAN,
    RangerWarden = NWScript.PACKAGE_RANGER_WARDEN,
    RangerStalker = NWScript.PACKAGE_RANGER_STALKER,
    RangerGiantkiller = NWScript.PACKAGE_RANGER_GIANTKILLER,
    RogueGypsy = NWScript.PACKAGE_ROGUE_GYPSY,
    RogueBandit = NWScript.PACKAGE_ROGUE_BANDIT,
    RogueScout = NWScript.PACKAGE_ROGUE_SCOUT,
    RogueSwashbuckler = NWScript.PACKAGE_ROGUE_SWASHBUCKLER,
    Shadowdancer = NWScript.PACKAGE_SHADOWDANCER,
    Harper = NWScript.PACKAGE_HARPER,
    ArcaneArcher = NWScript.PACKAGE_ARCANE_ARCHER,
    Assassin = NWScript.PACKAGE_ASSASSIN,
    Blackguard = NWScript.PACKAGE_BLACKGUARD,
    NpcSorcerer = NWScript.PACKAGE_NPC_SORCERER,
    NpcRogue = NWScript.PACKAGE_NPC_ROGUE,
    NpcBard = NWScript.PACKAGE_NPC_BARD,
    Aberration = NWScript.PACKAGE_ABERRATION,
    Animal = NWScript.PACKAGE_ANIMAL,
    Construct = NWScript.PACKAGE_CONSTRUCT,
    Humanoid = NWScript.PACKAGE_HUMANOID,
    Monstrous = NWScript.PACKAGE_MONSTROUS,
    Elemental = NWScript.PACKAGE_ELEMENTAL,
    Fey = NWScript.PACKAGE_FEY,
    Dragon = NWScript.PACKAGE_DRAGON,
    Undead = NWScript.PACKAGE_UNDEAD,
    Commoner = NWScript.PACKAGE_COMMONER,
    Beast = NWScript.PACKAGE_BEAST,
    Giant = NWScript.PACKAGE_GIANT,
    Magicbeast = NWScript.PACKAGE_MAGICBEAST,
    Outsider = NWScript.PACKAGE_OUTSIDER,
    Shapechanger = NWScript.PACKAGE_SHAPECHANGER,
    Vermin = NWScript.PACKAGE_VERMIN,
    DwarvenDefender = NWScript.PACKAGE_DWARVEN_DEFENDER,
    BarbarianBlackguard = NWScript.PACKAGE_BARBARIAN_BLACKGUARD,
    BardHarper = NWScript.PACKAGE_BARD_HARPER,
    ClericDivine = NWScript.PACKAGE_CLERIC_DIVINE,
    DruidShifter = NWScript.PACKAGE_DRUID_SHIFTER,
    FighterWeaponmaster = NWScript.PACKAGE_FIGHTER_WEAPONMASTER,
    MonkAssassin = NWScript.PACKAGE_MONK_ASSASSIN,
    PaladinDivine = NWScript.PACKAGE_PALADIN_DIVINE,
    RangerArcanearcher = NWScript.PACKAGE_RANGER_ARCANEARCHER,
    RogueShadowdancer = NWScript.PACKAGE_ROGUE_SHADOWDANCER,
    SorcererDragondisciple = NWScript.PACKAGE_SORCERER_DRAGONDISCIPLE,
    WizardPalemaster = NWScript.PACKAGE_WIZARD_PALEMASTER,
    NpcWizassassin = NWScript.PACKAGE_NPC_WIZASSASSIN,
    NpcFtWeaponmaster = NWScript.PACKAGE_NPC_FT_WEAPONMASTER,
    NpcRgShadowdancer = NWScript.PACKAGE_NPC_RG_SHADOWDANCER,
    NpcClericLinu = NWScript.PACKAGE_NPC_CLERIC_LINU,
    NpcBarbarianDaelan = NWScript.PACKAGE_NPC_BARBARIAN_DAELAN,
    NpcBardFighter = NWScript.PACKAGE_NPC_BARD_FIGHTER,
    NpcPaladinFalling = NWScript.PACKAGE_NPC_PALADIN_FALLING,
    Shifter = NWScript.PACKAGE_SHIFTER,
    DivineChampion = NWScript.PACKAGE_DIVINE_CHAMPION,
    PaleMaster = NWScript.PACKAGE_PALE_MASTER,
    DragonDisciple = NWScript.PACKAGE_DRAGON_DISCIPLE,
    Weaponmaster = NWScript.PACKAGE_WEAPONMASTER,
    NpcFtWeaponmasterValen2 = NWScript.PACKAGE_NPC_FT_WEAPONMASTER_VALEN_2,
    NpcBardFighterSharwyn2 = NWScript.PACKAGE_NPC_BARD_FIGHTER_SHARWYN2,
    NpcWizassassinNathyrra = NWScript.PACKAGE_NPC_WIZASSASSIN_NATHYRRA,
    NpcRgTomi2 = NWScript.PACKAGE_NPC_RG_TOMI_2,
    NpcBardDeekin2 = NWScript.PACKAGE_NPC_BARD_DEEKIN_2,
    BarbarianBlackguard2Ndclass = NWScript.PACKAGE_BARBARIAN_BLACKGUARD_2NDCLASS,
    BardHarper2Ndclass = NWScript.PACKAGE_BARD_HARPER_2NDCLASS,
    ClericDivine2Ndclass = NWScript.PACKAGE_CLERIC_DIVINE_2NDCLASS,
    DruidShifter2Ndclass = NWScript.PACKAGE_DRUID_SHIFTER_2NDCLASS,
    FighterWeaponmaster2Ndclass = NWScript.PACKAGE_FIGHTER_WEAPONMASTER_2NDCLASS,
    MonkAssassin2Ndclass = NWScript.PACKAGE_MONK_ASSASSIN_2NDCLASS,
    PaladinDivine2Ndclass = NWScript.PACKAGE_PALADIN_DIVINE_2NDCLASS,
    RangerArcanearcher2Ndclass = NWScript.PACKAGE_RANGER_ARCANEARCHER_2NDCLASS,
    RogueShadowdancer2Ndclass = NWScript.PACKAGE_ROGUE_SHADOWDANCER_2NDCLASS,
    SorcererDragondisciple2Ndclass = NWScript.PACKAGE_SORCERER_DRAGONDISCIPLE_2NDCLASS,
    WizardPalemaster2Ndclass = NWScript.PACKAGE_WIZARD_PALEMASTER_2NDCLASS,
    NpcAribethPaladin = NWScript.PACKAGE_NPC_ARIBETH_PALADIN,
    NpcAribethBlackguard = NWScript.PACKAGE_NPC_ARIBETH_BLACKGUARD,
    Invalid = NWScript.PACKAGE_INVALID,
  }
}
