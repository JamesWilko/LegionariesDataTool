
require("abilities/upgrade_unit")

if {Unit.UpgradeAbility} == nil then
	{Unit.UpgradeAbility} = class(upgrade_unit)
end

function {Unit.UpgradeAbility}:GetUpgradeClass()
	return "{Unit.ID}"
end
