import { Component, inject, input } from '@angular/core';
import {
  ApplicationModelsApiModelsApiRequirementSpecificationPerson
} from "../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import {joinWithConjunction} from "../../../../shared/tools/string-join-tools";
import {LocaleDataProvider} from "../../../../core/services/locale-data.service";
import {stringEmptyPropagate} from "../../../../shared/tools/null-tools";
import {ApiProjectModel} from "../../models/api-project-model";
import {MatIconModule} from "@angular/material/icon";
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {parseEffortHours} from "../../../../shared/tools/parsing";
import { map, of } from 'rxjs';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-requirement-persons',
  imports: [MatIconModule, TranslateModule, AsyncPipe],
  templateUrl: './requirement-persons.component.html',
  styleUrl: './requirement-persons.component.scss'
})
export class RequirementPersonsComponent {
  translateService = inject(TranslateService)
  requirements = input<ApplicationModelsApiModelsApiRequirementSpecificationPerson[]>([])
  localDataProvider = inject(LocaleDataProvider)
  
  quantityText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    return stringEmptyPropagate(requirement?.quantitySpecification?.value, "-");
  }

  skillText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    return stringEmptyPropagate(joinWithConjunction(requirement?.skillSpecifications?.map(x => x.title?.rawContentString).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-");
    
  }

  workloadText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    const effortHours = parseEffortHours(requirement?.workAmountSpecification?.value)
    return this.translateService.stream(`effortHoursType.${effortHours.effortHoursType}`).pipe(map(x => `${stringEmptyPropagate(effortHours.effortHours, "-")} ${x}`));
  }

  periodText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    if(requirement.timeSpecificationSameAsProject){
      return this.translateService.stream("general.inTheSameTimeOfTheProject")
    }
    return of(stringEmptyPropagate(joinWithConjunction(requirement?.timeSpecifications?.map(x => ApiProjectModel.getTimeSpecificationShortName(x, this.localDataProvider)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-"));
  }
  locationText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    if(requirement.locationSpecificationsSameAsProject){
      return this.translateService.stream("general.atTheSameLocationOfTheProject")
    }
    return of(stringEmptyPropagate(joinWithConjunction(requirement?.locationSpecifications?.map(x => ApiProjectModel.getLocationSpecificationShortName(x, this.localDataProvider, this.translateService)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-"));
  }
}
