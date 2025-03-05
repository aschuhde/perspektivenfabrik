import { ApplicationModelsApiModelsApiRequirementSpecificationMaterial } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMaterial";
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import { SelectOptionMaterial } from "../../../shared/models/select-option-material";
import { LocationInput } from "./location-input";
import { ProjectTimeInput } from "./project-time-input";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationPerson
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import {SelectOption} from "../../../shared/models/select-option";

export class RequirementMaterialInput{
    entityId: string | null = null;
    quantitySpecificationEntityId: string | null = null;
  selectedMaterials: SelectOptionMaterial[] = [];  
  requirementTimeIsIdenticalToProjectTime: boolean = true
  requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
  requirementLocationIsIdenticalToProjectLocation: boolean = true
  requirementLocations: LocationInput[] = [new LocationInput()];
    
  toRequirementMaterialSpecifications(): ApplicationModelsApiModelsApiRequirementSpecificationMaterial[] {
    return this.selectedMaterials.map((x, index) => {
        return {
            classType: ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material,
            entityId: index === 0 ? this.entityId ?? undefined: undefined,
            quantitySpecification: {
                value: x.amount,
                entityId: index === 0 ? this.quantitySpecificationEntityId ?? undefined : undefined
            },            
            materialSpecifications: [{
                name: x.value,
                entityId: x.entityId ?? undefined,
                title: {
                    rawContentString: x.text
                },
                description: {
                    rawContentString: x.description
                },
                amountValue: x.amount
            }],            
            timeSpecificationSameAsProject: this.requirementTimeIsIdenticalToProjectTime,
            locationSpecificationsSameAsProject: this.requirementLocationIsIdenticalToProjectLocation,
            locationSpecifications: this.requirementLocationIsIdenticalToProjectLocation ? [] : this.requirementLocations.map(x => x.toLocationSpecification()).filter(x => !!x),
            timeSpecifications:  this.requirementTimeIsIdenticalToProjectTime ? [] : this.requirementTimes.map(x => x.toTimeSpecification()).filter(x => !!x)            
        }
    })
  }

  static fromRequirementSpecification(requirementSpecification: ApplicationModelsApiModelsApiRequirementSpecificationMaterial) {
    const result = new RequirementMaterialInput();
    result.entityId = requirementSpecification.entityId ?? null;
    result.quantitySpecificationEntityId = requirementSpecification.quantitySpecification?.entityId ?? null;
    result.requirementTimeIsIdenticalToProjectTime = requirementSpecification.timeSpecificationSameAsProject ?? true;
    result.requirementLocationIsIdenticalToProjectLocation = requirementSpecification.locationSpecificationsSameAsProject ?? true;
    result.requirementLocations = requirementSpecification.locationSpecifications?.map(x => LocationInput.fromLocationSpecification(x))?.filter(x => !!x) ?? [];
    result.requirementTimes = requirementSpecification.timeSpecifications?.map(x => ProjectTimeInput.fromTimeSpecification(x))?.filter(x => !!x) ?? [];
    result.selectedMaterials = requirementSpecification.materialSpecifications?.map(x => new SelectOptionMaterial(x.name ?? "", x.title?.rawContentString ?? "", x.amountValue ?? "", x.description?.rawContentString ?? "", x.entityId ?? null)).filter(x => !!x.value) ?? [];
    return result;
  }
}