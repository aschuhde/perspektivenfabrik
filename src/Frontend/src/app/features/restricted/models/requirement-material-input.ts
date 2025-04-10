import { ApplicationModelsApiModelsApiRequirementSpecificationMaterial } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMaterial";
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import { SelectOptionMaterial } from "../../../shared/models/select-option-material";
import { LocationInput } from "./location-input";
import { ProjectTimeInput } from "./project-time-input";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationPerson
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import {SelectOption} from "../../../shared/models/select-option";
import {ObjectCreator} from "../../../shared/tools/object-creator";

export class RequirementMaterialInput{
    entityId: string | null = null;
    quantitySpecificationEntityId: string | null = null;
    quantitySpecificationValue: string | null = null;
    selectedMaterials: SelectOptionMaterial[] = [];  
    requirementTimeIsIdenticalToProjectTime: boolean = true
    requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
    requirementLocationIsIdenticalToProjectLocation: boolean = true
    requirementLocations: LocationInput[] = [new LocationInput()];
    
  toRequirementMaterialSpecifications(): ApplicationModelsApiModelsApiRequirementSpecificationMaterial {
    return ObjectCreator.Create<ApplicationModelsApiModelsApiRequirementSpecificationMaterial>({
      classType: ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material,
      entityId: this.entityId ?? undefined,
      quantitySpecification: {
        value: this.quantitySpecificationValue ?? "",
        entityId: this.quantitySpecificationEntityId ?? undefined,
      },
      materialSpecifications: this.selectedMaterials.map(x => {
        return {
          name: x.value,
          entityId: x.entityId ?? undefined,
          title: {
            rawContentString: x.text
          },
          description: {
            rawContentString: x.description
          },
          amountValue: x.amount
        }
      }),
      timeSpecificationSameAsProject: this.requirementTimeIsIdenticalToProjectTime,
      locationSpecificationsSameAsProject: this.requirementLocationIsIdenticalToProjectLocation,
      locationSpecifications: this.requirementLocationIsIdenticalToProjectLocation ? [] : this.requirementLocations.map(x => x.toLocationSpecification()).filter(x => !!x),
      timeSpecifications:  this.requirementTimeIsIdenticalToProjectTime ? [] : this.requirementTimes.map(x => x.toTimeSpecification()).filter(x => !!x)
    });
  }

  static fromRequirementSpecification(requirementSpecification: ApplicationModelsApiModelsApiRequirementSpecificationMaterial) {
    const result = new RequirementMaterialInput();
    result.entityId = requirementSpecification.entityId ?? null;
    result.quantitySpecificationValue = requirementSpecification.quantitySpecification?.value ?? null;
    result.quantitySpecificationEntityId = requirementSpecification.quantitySpecification?.entityId ?? null;
    result.requirementTimeIsIdenticalToProjectTime = requirementSpecification.timeSpecificationSameAsProject ?? true;
    result.requirementLocationIsIdenticalToProjectLocation = requirementSpecification.locationSpecificationsSameAsProject ?? true;
    result.requirementLocations = requirementSpecification.locationSpecifications?.map(x => LocationInput.fromLocationSpecification(x))?.filter(x => !!x) ?? [];
    result.requirementTimes = requirementSpecification.timeSpecifications?.map(x => ProjectTimeInput.fromTimeSpecification(x))?.filter(x => !!x) ?? [];
    result.selectedMaterials = requirementSpecification.materialSpecifications?.map(x => new SelectOptionMaterial(x.name ?? "", x.title?.rawContentString ?? "", x.amountValue ?? "", x.description?.rawContentString ?? "", x.entityId ?? null)).filter(x => !!x.value) ?? [];
    return result;
  }
}