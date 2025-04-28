import { Component, inject, model, output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { RequirementMaterialInput } from '../../models/requirement-material-input';
import { EditRequirementMaterialComponent } from '../../dialogs/edit-requirement-material/edit-requirement-material.component';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-input-requirement-material',
  imports: [FormsModule, MatIcon, TranslateModule],
  templateUrl: './input-requirement-material.component.html',
  styleUrl: './input-requirement-material.component.scss'
})
export class InputRequirementMaterialComponent {
  readonly dialog = inject(MatDialog);

  requirementMaterial = model.required<RequirementMaterialInput>();
  remove = output<RequirementMaterialInput>();
  
  requirementIndex = model.required<number>();
    onChanged = output();
    
  get requirementNumber(){
    return this.requirementIndex() + 1;
  }

  get subText(){
    return this.requirementMaterial().selectedMaterials.map(x => x.text).join(", ");
  }
  
  openInDialog(){
    this.dialog.open(EditRequirementMaterialComponent, {
      data: {
        requirementMaterial: this.requirementMaterial(),
        requirementIndex: this.requirementIndex(),
          onChanged: () => { this.onChanged.emit(); }
      }
    });
  }

  removeClicked(){
    this.remove.emit(this.requirementMaterial());
  }  

}
