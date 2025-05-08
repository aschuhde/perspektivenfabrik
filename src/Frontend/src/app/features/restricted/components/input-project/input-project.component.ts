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
import {AngularEditorConfig, AngularEditorModule} from '@kolkov/angular-editor';
import {UploadedImage} from '../../../../shared/models/uploaded-image';
import {ProjectInput, ProjectType} from '../../models/project-input';
import {MatChipInputEvent, MatChipsModule} from '@angular/material/chips';
import {MatAutocompleteModule, MatAutocompleteSelectedEvent} from '@angular/material/autocomplete';
import {COMMA, ENTER, TAB} from '@angular/cdk/keycodes';
import {SelectOption} from '../../../../shared/models/select-option';
import {InputContactSpecificationComponent} from '../input-contact-specification/input-contact-specification.component';
import {ContactSpecification} from '../../models/contact-specification';
import {ProjectSaveContext} from "../../models/project-save-context";
import {formatDate, formatTime} from "../../../../shared/tools/date-tools";
import {LocaleDataProvider} from "../../../../core/services/locale-data.service";
import { ConfirmDialogComponent } from '../../../../shared/dialogs/confirm-dialog/confirm-dialog.component';
import {RestrictedRouteNames} from "../../restricted-route-names";
import {HomeRouteNames} from "../../../home/home-route-names";
import { ShareLinkDialogComponent } from '../../dialogs/share-link-dialog/share-link-dialog.component';
import {AutocompleteDataService} from "../../../../shared/services/autocomplete-data.service";
import {ApiService} from "../../../../server/api/api.service";
import {Observable} from "rxjs";
import {HttpEvent, HttpEventType, HttpRequest, HttpResponse} from "@angular/common/http";
import {UploadResponse} from "@kolkov/angular-editor/lib/angular-editor.service";
import {BASE_PATH} from "../../../../server/variables";
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {Language} from "../../../../core/types/general-types";

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
        InputContactSpecificationComponent,
        TranslateModule],
    templateUrl: './input-project.component.html',
    styleUrl: './input-project.component.scss'
})
export class InputProjectComponent {
    apiBasePath = inject(BASE_PATH);
    readonly dialog = inject(MatDialog);
    apiService = inject(ApiService);
    isLoading = input(false); 
    readonly addOnBlur = false;
    readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;
    projectInput = model.required<ProjectInput>();
    onSave = output();
    onDelete = output();
    currentGroup: string = "projectType";
    @ViewChild('fileUpload') 
    fileUpload!: ElementRef;
    currentRequirementGroup: "person" | "material" | "money" = "person";
    tagAutocompleteValue = model("");
    tagOptions: SelectOption[] = [];
    isSaving: boolean = false
    projectSaveContext = input<ProjectSaveContext | null>(null);
    localeDataProvider = inject(LocaleDataProvider);
    static IgnoreUnloadEvent = false;
    autoCompleteDataService = inject(AutocompleteDataService);
    translateService = inject(TranslateService);
    angularEditorConfig: AngularEditorConfig = {
      editable: true,
      spellcheck: true,
      enableToolbar: true,
      showToolbar: true,
      upload: (file: File) => {
        if(!this.projectInput().entityId){
          this.showMessageDialog({
            message: this.translateService.instant("messages.fileValidationNotSavedMessage"),
            title: this.translateService.instant("messages.fileValidationNotSavedTitle"),
            buttonText: "Ok"
          });
          return new Observable<HttpEvent<UploadResponse>>((subscriber) => {
            subscriber.error();
          });
        }
        if(file.size >= 1024 * 1024 * 5) {
          this.showMessageDialog({
            message: this.translateService.instant("messages.fileValidationTooLargeMessage"),
            title: this.translateService.instant("messages.fileValidationTooLargeTitle"),
            buttonText: "Ok"
          });
          return new Observable<HttpEvent<UploadResponse>>((subscriber) => {
            subscriber.error();
          });
        }
        return new Observable<HttpEvent<UploadResponse>>((subscriber) => {
          new UploadedImage(file).getBase64().then(x => {
            this.apiService.webApiEndpointsPostDescriptionImage({
              image: {
                content: x
              }
            }, this.projectInput().entityId!).subscribe(y => {
              if(!y.imageIdentifier){
                this.showMessageDialog({
                  message: this.translateService.instant("messages.imageUploadFailedMessage"),
                  title: this.translateService.instant("messages.imageUploadFailedTitle"),
                  buttonText: "Ok"
                });
                return subscriber.error();
              }
              subscriber.next(new HttpResponse<UploadResponse>({
                body: {
                  imageUrl: `${this.apiBasePath}/api/projects/${this.projectInput().entityId}/description-images/${y.imageIdentifier}`
                },
                status: 200
              }));
              subscriber.complete();
            })
          })
        });
      },
      uploadWithCredentials: false,
      sanitize: true,
      fonts: [{class: "DM Sans", name: "DM Sans"}],
      toolbarHiddenButtons: [[
        'fontName',
        'textColor',
        'backgroundColor',
        'customClasses',
        'insertVideo',
        'insertHorizontalRule']]
    }
    ngOnInit(){
      this.autoCompleteDataService.getTags().then(x => {
        this.tagOptions = x?.filter(y => !!y).map(y => new SelectOption(y.name ?? "")) ?? [];
      })
    }
  
    constructor() {
      window.addEventListener("beforeunload", (event) => {
        if(InputProjectComponent.IgnoreUnloadEvent){
          return;
        }
        if(this.projectSaveContext()?.hasChanges ?? false){
          event.preventDefault();
          event.returnValue = true;
        }
      });
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
    get isNewProject(): boolean {
      return !this.projectInput().entityId;
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
    if(this.currentLanguage === "it"){
      switch(this.projectType){
        case "project":
        case "none":
          return "progetto";
        case "idea":
          return "idea";
        case "inspiration":
          return "ispirazione";
      }
    }
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
  if(this.currentLanguage === "it"){
    return this.typeName;
  }
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
  get currentLanguage(){
      return this.translateService.currentLang as Language;
  }
  get yourDeclination(){
    if(this.currentLanguage === "it"){
      switch(this.projectType){
        case "project":
        case "none":
          return "il tuo";
        case "idea":
          return "la tua";
        case "inspiration":
          return "la tua";
      }  
    }
      
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
    if(this.currentLanguage === "it"){
      switch(this.projectType){
        case "project":
        case "none":
          return "del tuo";
        case "idea":
          return "della tua";
        case "inspiration":
          return "della tua";
      }
    }
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
      if(this.currentLanguage === "it"){
        switch(this.projectType){
          case "project":
          case "none":
            return "del tuo";
          case "idea":
            return "della tua";
          case "inspiration":
            return "della tua";
        }
      }
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

  get yoursDeclinationDativeTo(){
    if(this.currentLanguage === "it"){
      switch(this.projectType){
        case "project":
        case "none":
          return "al tuo";
        case "idea":
          return "alla tua";
        case "inspiration":
          return "alla tua";
      }
    }
    return this.yoursDeclinationDative;
  }


  get messageDialogs(){
    return {
      helpProjectType: new MessageDialogData({
        message: this.translateService.instant("messages.helpProjectTypeMessage"),
        title: this.translateService.instant("messages.helpProjectTypeTitle")
      }),
      helpProjectTitle: new MessageDialogData({
        message: this.translateService.instant("messages.helpProjectTitleMessage", {"yoursDeclination": this.yoursDeclination, "typeName": this.typeName}),
        title: this.translateService.instant("messages.helpProjectTitleTitle")
      }),
      helpProjectPhase: new MessageDialogData({
        message: this.translateService.instant(`messages.helpProjectPhaseMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpProjectPhaseTitle`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName})
      }),
      helpProjectLocation: new MessageDialogData({
        message: this.translateService.instant(`messages.helpProjectLocationMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpProjectLocationTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeName})
      }),
      helpProjectTime: new MessageDialogData({
        message: this.translateService.instant(`messages.helpProjectTimeMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpProjectTimeTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeName})
      }),
      helpRequirements: new MessageDialogData({
        message: this.translateService.instant(`messages.helpRequirementsMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpRequirementsTitle`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName})
      }),
      helpContact: new MessageDialogData({
        message: this.translateService.instant(`messages.helpContactMessage`, {"yourDeclination": this.yourDeclination, "yoursDeclination": this.yoursDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpContactTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeName})
      }),
      helpDescription: new MessageDialogData({
        message: this.translateService.instant(`messages.helpDescriptionMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpDescriptionTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeName})
      }),
      helpImageUpload: new MessageDialogData({
        message: this.translateService.instant(`messages.helpImageUploadMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpImageUploadTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeName})
      }),
      helpProjectVisibility: new MessageDialogData({
        message: this.translateService.instant(`messages.helpProjectVisibilityMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpProjectVisibilityTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeName})
      }), 
        helpTags: new MessageDialogData({
            message: this.translateService.instant(`messages.helpTagsMessage`, {"yoursDeclinationDativeTo": this.yoursDeclinationDativeTo, "typeName": this.typeName}),
            title: this.translateService.instant(`messages.helpTagsTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeName})
        })
    };
  }

  showMessageDialog(dialogData: Partial<MessageDialogData>) {
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
        data: new MessageDialogData({
            isHtmlMessage: true,
            message: this.translateService.instant("messages.fileTooLargeMessage", { uploadedFilesList: `<br>${tooLargeFiles.map(x => `${x.name} - ${(x.size / (1014 * 1024)).toLocaleString(undefined, {maximumFractionDigits: 1})}`).join("<br>") }` }),
            title: this.translateService.instant("messages.fileTooLargeTitle")
        })
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
    if(groupName === this.currentGroup) return;
    this.currentGroup = groupName;
    
    const url = new URL(window.location.href);
    url.searchParams.set("group", groupName);
    window.history.replaceState({}, '', url.toString());
  }
  
  getGroups(){
        return ['projectType', 'projectName', 'projectPhase', 'projectLocation', 'projectTime', 'projectRequirements'
            , 'projectContact', 'projectTags', 'projectDescription', 'projectImages', 'projectVisibility']
  }
  
  selectNext(){
    const groups = this.getGroups();
    const currentGroupIndex = groups.indexOf(this.currentGroup);
    if(currentGroupIndex < 0) {
        this.select(groups[0]);
    }
    if(currentGroupIndex >= groups.length - 1){
        return;
    }
    let nextGroup = groups[currentGroupIndex+1];
    if(nextGroup === 'projectPhase' && this.projectType !== "project"){
        nextGroup = groups[currentGroupIndex+2];
    }
    this.select(nextGroup);
  }
  
  selectPrevious(){
    const groups = this.getGroups();
    const currentGroupIndex = groups.indexOf(this.currentGroup);
    if(currentGroupIndex < 0) {
        this.select(groups[0]);
    }
    if(currentGroupIndex === 0){
        return;
    }
    let prevGroup = groups[currentGroupIndex-1];
    if(prevGroup === 'projectPhase' && this.projectType !== "project"){
        prevGroup = groups[currentGroupIndex-2];
    }
    this.select(prevGroup);
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
  formatTime(date: Date | null) {
    return formatTime(date, this.localeDataProvider.locale);
  }

  removeUploadedImage(image: UploadedImage) {
    this.uploadedImages = this.uploadedImages.filter(x => x !== image);
    this.onUpdated();
  }

  deleteProject() {
    this.dialog.open(ConfirmDialogComponent, {
      data: {
        title: "Wirklich löschen?",
        message: "Willst du das Projekt wirklich löschen?",
        confirmButtonText: "Ja",
        cancelButtonText: "Abbrechen",
        onConfirm: () => {
          this.onDelete.emit();
        }
      }
    });
  }
  
  get internalLink(){
      const entityId = this.projectInput().entityId;
      if(!entityId) return "#";
      return window.location.origin + HomeRouteNames.InternalProjectUrl(entityId)
  }
  get previewLink(){
    const entityId = this.projectInput().entityId;
    if(!entityId) return "#";
    return RestrictedRouteNames.PreviewProjectUrl(entityId);
  }

  openShareLinkDialog(){
      this.dialog.open(ShareLinkDialogComponent, {
        data: {
          link: this.internalLink
        }
      })
  }
}
