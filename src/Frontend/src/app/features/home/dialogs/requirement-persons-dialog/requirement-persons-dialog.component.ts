import {Component, inject} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogTitle
} from "@angular/material/dialog";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationPerson
} from "../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import {RequirementPersonsComponent} from "../../components/requirement-persons/requirement-persons.component";
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-requirement-persons-dialog',
  imports: [MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, RequirementPersonsComponent, TranslateModule],
  templateUrl: './requirement-persons-dialog.component.html',
  styleUrl: './requirement-persons-dialog.component.scss'
})
export class RequirementPersonsDialogComponent {
  data = inject(MAT_DIALOG_DATA);
  requirementPersons: ApplicationModelsApiModelsApiRequirementSpecificationPerson[] = this.data?.requirementPersons ?? [];
}
