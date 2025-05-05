import { Component, inject, input } from '@angular/core';
import {
  ApplicationModelsApiModelsApiRequirementSpecificationPerson
} from "../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import {joinWithConjunction} from "../../../../shared/tools/string-join-tools";
import {LocaleDataProvider} from "../../../../core/services/locale-data.service";
import {stringEmptyPropagate} from "../../../../shared/tools/null-tools";
import {ApiProjectModel} from "../../models/api-project-model";
import {MatIconModule} from "@angular/material/icon";
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-requirement-persons',
  imports: [MatIconModule, TranslateModule],
  templateUrl: './requirement-persons.component.html',
  styleUrl: './requirement-persons.component.scss'
})
export class RequirementPersonsComponent {
  requirements = input<ApplicationModelsApiModelsApiRequirementSpecificationPerson[]>([])
  localDataProvider = inject(LocaleDataProvider)
  
  quantityText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    return stringEmptyPropagate(requirement?.quantitySpecification?.value, "-");
  }

  skillText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    return stringEmptyPropagate(joinWithConjunction(requirement?.skillSpecifications?.map(x => x.title?.rawContentString).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-");
    
  }

  workloadText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    return stringEmptyPropagate(requirement?.workAmountSpecification?.value, "-");
  }

  periodText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    if(requirement.timeSpecificationSameAsProject){
      return "Im gleichen Zeitraum des Projekts"
    }
    return stringEmptyPropagate(joinWithConjunction(requirement?.timeSpecifications?.map(x => ApiProjectModel.getTimeSpecificationShortName(x, this.localDataProvider)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-");
  }
  locationText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    if(requirement.locationSpecificationsSameAsProject){
      return "Am gleichen Ort wie das Projekt"
    }
    return stringEmptyPropagate(joinWithConjunction(requirement?.locationSpecifications?.map(x => ApiProjectModel.getLocationSpecificationShortName(x, this.localDataProvider)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-");
  }
}
