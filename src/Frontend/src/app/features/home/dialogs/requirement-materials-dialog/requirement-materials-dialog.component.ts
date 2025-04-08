import {Component, inject} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogTitle
} from "@angular/material/dialog";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationMaterial
} from "../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMaterial";
import { ApplicationModelsApiModelsApiRequirementSpecificationMoney } from '../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMoney';
import {RequirementMaterialsComponent} from "../../components/requirement-materials/requirement-materials.component";
import {RequirementPersonsComponent} from "../../components/requirement-persons/requirement-persons.component";

@Component({
  selector: 'app-requirement-materials-dialog',
  imports: [MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, RequirementMaterialsComponent, RequirementPersonsComponent],
  templateUrl: './requirement-materials-dialog.component.html',
  styleUrl: './requirement-materials-dialog.component.scss'
})
export class RequirementMaterialsDialogComponent {
  data = inject(MAT_DIALOG_DATA);
  requirementMaterials: ApplicationModelsApiModelsApiRequirementSpecificationMaterial[] = this.data?.requirementMaterials ?? [];
  requirementsMoney: ApplicationModelsApiModelsApiRequirementSpecificationMoney[] = this.data?.requirementsMoney ?? [];
}
