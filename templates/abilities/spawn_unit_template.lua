
require("{Unit.SummonAbilityBaseClassPath}")

if {Unit.SummonAbility} == nil then
	{Unit.SummonAbility} = class({Unit.SummonAbilityBaseClass})
end

function {Unit.SummonAbility}:GetSpawnUnit()
	return "{Unit.ID}"
end
