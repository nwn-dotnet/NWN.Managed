namespace Anvil.Services
{
  public enum ValidationFailureSubType
  {
    None = 0,
    ServerLevelRestriction,
    LevelHack,
    ColoredName,
    UnidentifiedEquippedItem,
    MinEquipLevel,
    NonPCCharacter,
    DMCharacter,
    NonPlayerRace,
    NonPlayerClass,
    ClassLevelRestriction,
    PrestigeClassRequirements,
    ClassAlignmentRestriction,
    StartingAbilityValueMax,
    AbilityPointBuySystemCalculation,
    ClassSpellcasterInvalidPrimaryStat,
    EpicLevelFlag,
    TooManyHitPoints,
    UnusableSkill,
    NotEnoughSkillPoints,
    InvalidNumRanksInClassSkill,
    InvalidNumRanksInNonClassSkill,
    InvalidNumRemainingSkillPoints,
    InvalidFeat,
    FeatRequiredSpellLevelNotMet,
    FeatRequiredBaseAttackBonusNotMet,
    FeatRequiredAbilityValueNotMet,
    FeatRequiredSkillNotMet,
    FeatRequiredFeatNotMet,
    TooManyFeatsThisLevel,
    FeatNotAvailableToClass,
    FeatIsNormalFeatOnly,
    FeatIsBonusFeatOnly,
    SpellInvalidSpellGainWizard,
    SpellInvalidSpellGainBardSorcerer,
    SpellInvalidSpellGainOtherClasses,
    InvalidSpell,
    SpellInvalidSpellLevel,
    SpellMinimumAbilityBardSorcererUnused,
    SpellMinimumAbilityWizardUnused,
    SpellMinimumAbility,
    SpellRestrictedSpellSchool,
    SpellAlreadyKnown,
    SpellWizardExceedsNumSpellsToAdd,
    IllegalRemovedSpell,
    RemovedNotKnownSpell,
    InvalidNumSpells,
    SpellListComparison,
    SkillListComparison,
    FeatListComparison,
    MiscSavingThrow,
    NumFeatComparison,
    InvalidClass,
  }
}
