import {Component, ElementRef, inject, ViewChild} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatStepperModule} from '@angular/material/stepper';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { MatDialog } from '@angular/material/dialog';
import {MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { LocationInput } from '../../models/location-input';
import { InputLocationComponent } from '../input-location/input-location.component';
import { InputProjectTimeComponent } from '../input-project-time/input-project-time.component';
import { ProjectTimeInput } from '../../models/project-time-input';
import { RequirementPersonInput } from '../../models/requirement-person-input';
import { RequirementMaterialInput } from '../../models/requirement-material-input';
import { RequirementMoneyInput } from '../../models/requirement-money-input';
import { InputRequirementMaterialComponent } from '../input-requirement-material/input-requirement-material.component';
import { InputRequirementMoneyComponent } from '../input-requirement-money/input-requirement-money.component';
import { InputRequirementPersonComponent } from '../input-requirement-person/input-requirement-person.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { provideHttpClient } from '@angular/common/http';
import { UploadedImage } from '../../../../shared/models/uploaded-image';

@Component({
  selector: 'app-input-project',
  imports: [MatStepperModule,
    FormsModule,    
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatIconModule,
    MatSelectModule,
    InputLocationComponent,
    InputProjectTimeComponent,
    InputRequirementMaterialComponent,
    InputRequirementMoneyComponent,
    InputRequirementPersonComponent,
    AngularEditorModule],
  templateUrl: './input-project.component.html',
  styleUrl: './input-project.component.scss'
})
export class InputProjectComponent {
  readonly dialog = inject(MatDialog);

  projectType: "project" | "idea" | "inspiration" | "none" = "none";
  projectTitle: string = ""
  projectPhase: "unknown" | "planning" | "ongoing" | "finished" | "cancelled" = "unknown";
  locations: LocationInput[] = [new LocationInput()];
  projectTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
  requirementPersons: RequirementPersonInput[] = [new RequirementPersonInput()];
  requirementMaterials: RequirementMaterialInput[] = [new RequirementMaterialInput()];
  requirementsMoney: RequirementMoneyInput[] = [new RequirementMoneyInput()];
  contactMail: string = ""
  contactPhone: string = ""
  description: string = ""
  @ViewChild('fileUpload') 
  fileUpload!: ElementRef;

  uploadedImages: UploadedImage[] = []
  projectVisibility: "draft" | "public" | "internal" = "draft"

  get projectName(){
    return this.projectTitle; //todo: generate name
  }
  get typeName(){
    switch(this.projectType){
      case "project":
      case "none":
        return "Projekt";
      case "idea":
        return "Idee";
      case "inspiration":
        return "Inspiration";
    }
  }
  get yourDeclination(){
    switch(this.projectType){
      case "project":
      case "none":
        return "dein";
      case "idea":
        return "deine";
      case "inspiration":
        return "deine";
    }
  }
  get yoursDeclination(){
    switch(this.projectType){
      case "project":
      case "none":
        return "deines";
      case "idea":
        return "deiner";
      case "inspiration":
        return "deiner";
    }
  }


  readonly messageDialogs = {
    helpProjectType: new MessageDialogData({
      message: "Du kannst Projekte, Ideen oder Inspirationen hinzufügen. Projekt sind...",
      title: "Was möchtest du hinzufügen?"
    }),
    helpProjectTitle: new MessageDialogData({
      message: `Der Titel ${this.yoursDeclination} ${this.typeName} wird auf der Platform angezeigt und kann Formatierungen enthalten. Der Name ${this.yoursDeclination} ${this.typeName} wird beispielsweise in Links verwendet.`,
      title: "Projekttitel und Projektname"
    }),
    helpProjectPhase: new MessageDialogData({
      message: `In welcher Phase befindet sich ${this.yourDeclination} ${this.typeName}...`,
      title: `In welcher Phase befindet sich ${this.yourDeclination} ${this.typeName}?`
    }),
    helpProjectLocation: new MessageDialogData({
      message: `Du kannst mehrere Orte für ${this.yourDeclination} ${this.typeName} hinzufügen. Du kannst Namen von Orten, Adressen oder Koordinaten verwenden. Findet ${this.yourDeclination} ${this.typeName} nur digital statt, wähle Remote aus`,
      title: `Orte ${this.yoursDeclination} ${this.typeName}?`
    }),
    helpProjectTime: new MessageDialogData({
      message: `Du kannst mehrere Zeitpunkte/Zeiträume für ${this.yourDeclination} ${this.typeName} hinzufügen. Du kannst konkrete Daten oder einen ganzen Monat auswählen. Wann du helfende Hände, Material oder Geld für ${this.yourDeclination} ${this.typeName} brauchst, kannst du weiter unten nochmal auswählen.`,
      title: `Projektzeiten ${this.yoursDeclination} ${this.typeName}?`
    }),
    helpRequirements: new MessageDialogData({
      message: `Du kannst Helfer*innen, Material und Finanzielle Unterstützung für ${this.yourDeclination} ${this.typeName} anfordern.`,
      title: `Unterstützung für ${this.yourDeclination} ${this.typeName}?`
    }),
    helpContact: new MessageDialogData({
      message: `todo.`,
      title: `todo?`
    }),
    helpDescription: new MessageDialogData({
      message: `todo.`,
      title: `todo?`
    }),
    helpImageUpload: new MessageDialogData({
      message: `todo.`,
      title: `todo?`
    }),
    helpProjectVisibility: new MessageDialogData({
      message: `todo.`,
      title: `todo?`
    })    
  };

  showMessageDialog(dialogData: MessageDialogData) {
    this.dialog.open(MessageDialogComponent, {
      data: dialogData
    });
  }

  addLocation(){
    this.locations.push(new LocationInput());
  }
  removeLocation(location: LocationInput){
    const index = this.locations.indexOf(location);
    if(index < 0) return;
    this.locations.splice(index, 1);
  }
  addProjectTime(){
    this.projectTimes.push(new ProjectTimeInput());
  }
  removeProjectTime(projectTime: ProjectTimeInput){
    const index = this.projectTimes.indexOf(projectTime);
    if(index < 0) return;
    this.projectTimes.splice(index, 1);
  }
  addRequirementPerson(){
    this.requirementPersons.push(new RequirementPersonInput());
  }
  removeRequirementPerson(requirementPerson: RequirementPersonInput){
    const index = this.requirementPersons.indexOf(requirementPerson);
    if(index < 0) return;
    this.requirementPersons.splice(index, 1);
  }
  addRequirementMaterial(){
    this.requirementMaterials.push(new RequirementMaterialInput());
  }
  removeRequirementMaterial(requirementMaterial: RequirementMaterialInput){
    const index = this.requirementMaterials.indexOf(requirementMaterial);
    if(index < 0) return;
    this.requirementMaterials.splice(index, 1);
  }
  addRequirementMoney(){
    this.requirementsMoney.push(new RequirementMoneyInput());
  }
  removeRequirementMoney(requirementMoney: RequirementMoneyInput){
    const index = this.requirementsMoney.indexOf(requirementMoney);
    if(index < 0) return;
    this.requirementsMoney.splice(index, 1);
  }

  onFileUpload(event: Event){
    const files: FileList = (event?.target as any).files ?? [];
    const tooLargeFiles: File[] = [];
    const validFiles: File[] = [];
    for(let i = 0; i < files.length; i++){
      const file = files.item(i);
      if(!file){
        continue;
      }
      if(file.size >= 1024 * 1024 * 20){
        tooLargeFiles.push(file);
      }else{
        validFiles.push(file);
      }
    }

    if(tooLargeFiles.length > 0){
      this.dialog.open(MessageDialogComponent, {
        data: {
          helpImageUpload: new MessageDialogData({
            message: `Bitte lade nur Bilder, deren Dateigröße kleiner als 20MB ist, hoch. Du hast versucht folgende Dateien hochzuladen, die aber zu groß sind:<br> ${tooLargeFiles.map(x => `${x.name} - ${(x.size / (1014 * 1024)).toLocaleString(undefined, {maximumFractionDigits: 1})}`).join("<br>")}`,
            title: `Datei zu groß`
          }) 
        }
      });      
    }

    if(validFiles.length <= 0){
      return;
    }
    
    this.uploadedImages.push(...validFiles.map(x => new UploadedImage(x)));
  }

  onUploadButtonClicked(){
    this.fileUpload.nativeElement.dispatchEvent(new MouseEvent("click", { bubbles: true }));
  }

}
