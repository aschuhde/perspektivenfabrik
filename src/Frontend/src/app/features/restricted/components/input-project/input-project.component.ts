import {Component, ElementRef, inject, input, model, output, ViewChild} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatStepperModule} from '@angular/material/stepper';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatDialog} from '@angular/material/dialog';
import {MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import {MessageDialogComponent} from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import {MessageDialogData} from '../../../../shared/models/message-dialog-data';
import {LocationInput} from '../../models/location-input';
import {InputLocationComponent} from '../input-location/input-location.component';
import {InputProjectTimeComponent} from '../input-project-time/input-project-time.component';
import {ProjectTimeInput} from '../../models/project-time-input';
import {RequirementPersonInput} from '../../models/requirement-person-input';
import {RequirementMaterialInput} from '../../models/requirement-material-input';
import {RequirementMoneyInput} from '../../models/requirement-money-input';
import {InputRequirementMaterialComponent} from '../input-requirement-material/input-requirement-material.component';
import {InputRequirementMoneyComponent} from '../input-requirement-money/input-requirement-money.component';
import {InputRequirementPersonComponent} from '../input-requirement-person/input-requirement-person.component';
import {AngularEditorModule} from '@kolkov/angular-editor';
import {UploadedImage} from '../../../../shared/models/uploaded-image';
import {ProjectInput, ProjectType} from '../../models/project-input';
import {MatChipInputEvent, MatChipsModule} from '@angular/material/chips';
import {MatAutocompleteModule, MatAutocompleteSelectedEvent} from '@angular/material/autocomplete';
import {COMMA, ENTER, TAB} from '@angular/cdk/keycodes';
import {SelectOption} from '../../../../shared/models/select-option';
import {InputContactSpecificationComponent} from '../input-contact-specification/input-contact-specification.component';
import {ContactSpecification} from '../../models/contact-specification';
import {ProjectSaveContext} from "../../models/project-save-context";
import {formatDate} from "../../../../shared/tools/date-tools";
import {LocaleDataProvider} from "../../../../core/services/locale-data.service";

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
        MatAutocompleteModule,
        MatChipsModule,
        AngularEditorModule,
        InputContactSpecificationComponent],
    templateUrl: './input-project.component.html',
    styleUrl: './input-project.component.scss'
})
export class InputProjectComponent {
  readonly dialog = inject(MatDialog);
    
    isLoading = input(false); 
    readonly addOnBlur = false;
    readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;
    projectInput = model.required<ProjectInput>();
    onSave = output();
    currentGroup: string = "projectType";
    @ViewChild('fileUpload') 
    fileUpload!: ElementRef;
    currentRequirementGroup: "person" | "material" | "money" = "person";
    tagAutocompleteValue = model("");
    tagOptions: SelectOption[] = [new SelectOption("Landwirtschaft"), new SelectOption("Tourismus"), new SelectOption("Sozial"), new SelectOption("Kommunikation"), new SelectOption("Migration"), new SelectOption("Mobilität")];
    isSaving: boolean = false
    projectSaveContext = input<ProjectSaveContext | null>(null);
    localeDataProvider = inject(LocaleDataProvider);

    constructor() {
      
      const queryParams = new URLSearchParams(window.location.search);
      const group = queryParams.get('group');
      if (group) {
        this.currentGroup = group;
      }
    }
    get selectedTags(){
        return this.projectInput().selectedTags;
    }
    set selectedTags(value: SelectOption[]){
        this.projectInput().selectedTags = value;
    }
  get projectType(): ProjectType {
    return this.projectInput().projectType;
  }

  set projectType(value: ProjectType) {
    this.projectInput().projectType = value;
      this.onUpdated();
  }

  get projectTitle(): string {
    return this.projectInput().projectTitle;
  }

  set projectTitle(value: string) {
    this.projectInput().projectTitle = value;
      this.onUpdated();
  }

  get projectPhase(): "unknown" | "planning" | "ongoing" | "finished" | "cancelled" {
    return this.projectInput().projectPhase;
  }

  set projectPhase(value: "unknown" | "planning" | "ongoing" | "finished" | "cancelled") {
    this.projectInput().projectPhase = value;
      this.onUpdated();
  }

  get locations(): LocationInput[] {
    return this.projectInput().locations;
  }

  set locations(value: LocationInput[]) {
    this.projectInput().locations = value;
  }

  get projectTimes(): ProjectTimeInput[] {
    return this.projectInput().projectTimes;
  }

  set projectTimes(value: ProjectTimeInput[]) {
    this.projectInput().projectTimes = value;
  }

  get requirementPersons(): RequirementPersonInput[] {
    return this.projectInput().requirementPersons;
  }

  set requirementPersons(value: RequirementPersonInput[]) {
    this.projectInput().requirementPersons = value;
  }

  get requirementMaterials(): RequirementMaterialInput[] {
    return this.projectInput().requirementMaterials;
  }

  set requirementMaterials(value: RequirementMaterialInput[]) {
    this.projectInput().requirementMaterials = value;
  }

  get requirementsMoney(): RequirementMoneyInput[] {
    return this.projectInput().requirementsMoney;
  }

  set requirementsMoney(value: RequirementMoneyInput[]) {
    this.projectInput().requirementsMoney = value;
  }

  get contactMail(): string {
    return this.projectInput().contactMail;
  }

  set contactMail(value: string) {
    this.projectInput().contactMail = value;
      this.onUpdated();
  }

  get contactPhone(): string {
    return this.projectInput().contactPhone;
  }

  set contactPhone(value: string) {
    this.projectInput().contactPhone = value;
      this.onUpdated();
  }

  get longDescription(): string {
    return this.projectInput().longDescription;
  }

  set longDescription(value: string) {
    this.projectInput().longDescription = value;
      this.onUpdated();
  }

  get shortDescription(): string {
    return this.projectInput().shortDescription;
  }

  set shortDescription(value: string) {
    this.projectInput().shortDescription = value;
      this.onUpdated();
  }

  get uploadedImages(): UploadedImage[] {
    return this.projectInput().uploadedImages;
  }

  set uploadedImages(value: UploadedImage[]) {
    this.projectInput().uploadedImages = value;
  }

  get projectVisibility(): "draft" | "public" | "internal" {
    return this.projectInput().projectVisibility;
  }

  set projectVisibility(value: "draft" | "public" | "internal") {
    this.projectInput().projectVisibility = value;
      this.onUpdated();
  }

  get projectName(){
    return this.projectInput().projectName;
  }

  get contactSpecifications(){
    return this.projectInput().contactSpecifications;
  }
  get contactName(){
    return this.projectInput().contactName;
  }
  set contactName(value: string) {
    this.projectInput().contactName = value;
      this.onUpdated();
  }

  get organisationName(){
    return this.projectInput().organisationName;
  }
  set organisationName(value: string) {
    this.projectInput().organisationName = value;
    this.onUpdated();
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
get typeNameGenitive(){
    switch(this.projectType){
        case "project":
        case "none":
            return "Projekts";
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

    get yoursDeclinationDative(){
        switch(this.projectType){
            case "project":
            case "none":
                return "deinem";
            case "idea":
                return "deiner";
            case "inspiration":
                return "deiner";
        }
    }


  get messageDialogs(){
    return {
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
      }), 
        helpTags: new MessageDialogData({
            message: `todo.`,
            title: `todo?`
        })
    };
  }

  showMessageDialog(dialogData: MessageDialogData) {
    this.dialog.open(MessageDialogComponent, {
      data: dialogData
    });
  }

  addLocation(){
    this.locations.push(new LocationInput());
      this.onUpdated();
  }
  removeLocation(location: LocationInput){
    const index = this.locations.indexOf(location);
    if(index < 0) return;
    this.locations.splice(index, 1);
      this.onUpdated();
  }
  addProjectTime(){
    this.projectTimes.push(new ProjectTimeInput());
      this.onUpdated();
  }
  removeProjectTime(projectTime: ProjectTimeInput){
    const index = this.projectTimes.indexOf(projectTime);
    if(index < 0) return;
    this.projectTimes.splice(index, 1);
      this.onUpdated();
  }
  addRequirementPerson(){
    this.requirementPersons.push(new RequirementPersonInput());
      this.onUpdated();
  }
  removeRequirementPerson(requirementPerson: RequirementPersonInput){
    const index = this.requirementPersons.indexOf(requirementPerson);
    if(index < 0) return;
    this.requirementPersons.splice(index, 1);
      this.onUpdated();
  }
  addRequirementMaterial(){
    this.requirementMaterials.push(new RequirementMaterialInput());
      this.onUpdated();
  }
  removeRequirementMaterial(requirementMaterial: RequirementMaterialInput){
    const index = this.requirementMaterials.indexOf(requirementMaterial);
    if(index < 0) return;
    this.requirementMaterials.splice(index, 1);
      this.onUpdated();
  }
  addRequirementMoney(){
    this.requirementsMoney.push(new RequirementMoneyInput());
      this.onUpdated();
  }
  removeRequirementMoney(requirementMoney: RequirementMoneyInput){
    const index = this.requirementsMoney.indexOf(requirementMoney);
    if(index < 0) return;
    this.requirementsMoney.splice(index, 1);
      this.onUpdated();
  }

  addContactSpecification(){
    this.contactSpecifications.push(new ContactSpecification());
      this.onUpdated();
  }
  removeContactSpecification(contactSpecification: ContactSpecification){
    const index = this.contactSpecifications.indexOf(contactSpecification);
    if(index < 0) return;
    this.contactSpecifications.splice(index, 1);
      this.onUpdated();
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
    this.fileUpload.nativeElement.value = "";
    this.onUpdated();
  }

  onUploadButtonClicked(){
    this.fileUpload.nativeElement.dispatchEvent(new MouseEvent("click", { bubbles: true }));
  }

  select(groupName: string){
    this.currentGroup = groupName;
    
    const url = new URL(window.location.href);
    url.searchParams.set("group", groupName);
    window.history.replaceState({}, '', url.toString());
  }

  stepNumber(baseNumber: number){    
    if(baseNumber <= 2){
      return baseNumber;
    }
    if(this.projectType === 'project'){
      return baseNumber;
    }
    return baseNumber - 1;
  }

  changeProjectType(projectType: ProjectType){
    this.projectType = projectType;
    setTimeout(() => {
      this.select("projectName");
    }, 400);    
  }

  setLogo(image: UploadedImage){
    if(!image.isLogo){
      image.isMainImage = false;       
    }
    this.uploadedImages.forEach(x => {
      if(x === image){
        x.isLogo = !x.isLogo;
        return;
      }
      x.isLogo = false;       
    });
      this.onUpdated();
  }

  setMainImage(image: UploadedImage){
    if(!image.isMainImage){
      image.isLogo = false;       
    }
    this.uploadedImages.forEach(x => {
      if(x === image){
        x.isMainImage = !x.isMainImage;
        return;
      }
      x.isMainImage = false;
    });
      this.onUpdated();
  }

  addSelectedTag(event: MatChipInputEvent): void {
      const value = (event.value || '').trim();

      if(!value){
          return;
      }

      if (!this.selectedTags.find(x => x.value === value)) {
          this.selectedTags.push(new SelectOption(value));
          this.onUpdated();
      }

      this.tagAutocompleteValue.set("");
      event.chipInput.clear();
  }

  tagSelected(event: MatAutocompleteSelectedEvent){
      event.option.deselect();
      if (!this.selectedTags.find(x => x.value === event.option.value)) {
          this.selectedTags.push(new SelectOption(event.option.value, event.option.viewValue));
          this.onUpdated();
      }
      this.tagAutocompleteValue.set("");
      setTimeout(() => {
          this.tagAutocompleteValue.set("");
      }, 1000);
  }
  removeSelectedTag(selectedSkill: SelectOption){
      const index = this.selectedTags.indexOf(selectedSkill);
      if(index < 0) return;
      this.selectedTags.splice(index, 1);
      this.onUpdated();
  }

  save() {
    this.onSave.emit();
  }

  onUpdated() {
    this.projectSaveContext()?.onChange(this.projectInput());
  }

  formatDate(date: Date | null) {
      return formatDate(date, this.localeDataProvider.locale);
  }

  removeUploadedImage(image: UploadedImage) {
    this.uploadedImages = this.uploadedImages.filter(x => x !== image);
    this.onUpdated();
  }
}
