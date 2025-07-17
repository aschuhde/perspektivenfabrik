import {Component, ElementRef, inject, input, model, output, PLATFORM_ID, SimpleChanges, ViewChild} from '@angular/core';
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
import {AngularEditorConfig, AngularEditorModule, UploadResponse} from '@kolkov/angular-editor';
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
import {HttpEvent, HttpResponse} from "@angular/common/http";
import {BASE_PATH} from "../../../../server/variables";
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {Language} from "../../../../core/types/general-types";
import {
    MatInputTranslationsComponent
} from "../../../../shared/components/mat-input-translations/mat-input-translations.component";
import {TranslationValue} from "../../../../shared/models/translation-value";
import {stringEmptyPropagate} from "../../../../shared/tools/null-tools";
import { isPlatformBrowser } from '@angular/common';
import {UrlService} from "../../../../core/services/url-service.service";

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
        TranslateModule, 
        MatInputTranslationsComponent],
    templateUrl: './input-project.component.html',
    styleUrl: './input-project.component.scss'
})
export class InputProjectComponent {
    
    urlService = inject(UrlService)
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
    isDescriptionOtherLanguageActive: boolean = false;
    descriptionMainLanguage = this.translateService.currentLang as Language;
    hasPastedToAngularEditorShortDescription = false;
    hasPastedToAngularEditorLongDescription = false;
    hasPastedToAngularEditorShortDescriptionOtherLanguage = false;
    hasPastedToAngularEditorLongDescriptionOtherLanguage = false;
    platformId = inject(PLATFORM_ID);
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
            this.apiService.webApiEndpointsPostProjectImage({
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
                  imageUrl: `${this.apiBasePath}/api/projects/${this.projectInput().entityId}/project-images/${y.imageIdentifier}`
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
          "indent",
          "outdent",
        'fontName',
        'textColor',
        'backgroundColor',
        'customClasses',
        'insertVideo',
        'insertHorizontalRule']]
    }
    
    ngOnInit(){
      this.autoCompleteDataService.getTags().then(x => {
        this.tagOptions = x?.filter(y => !!y).map(y => {
          const valueTranslations = TranslationValue.arrayFromApiTranslationValues(y.nameTranslations ?? []);
          return new SelectOption(TranslationValue.getTranslationIfExist(y.name ?? "", valueTranslations, this.translateService.currentLang as Language), null, null, valueTranslations);
        }) ?? [];
      })
      this.descriptionMainLanguage = this.translateService.currentLang as Language;
    }
  
    constructor() {
      if(isPlatformBrowser(this.platformId)) {
        window.addEventListener("beforeunload", (event) => {
          if (InputProjectComponent.IgnoreUnloadEvent) {
            return;
          }
          if (this.projectSaveContext()?.hasChanges ?? false) {
            event.preventDefault();
            event.returnValue = true;
          }
        });
      }
      const group = this.urlService.getQueryParameter("group");
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

  get projectTitleTranslations(): TranslationValue[] {
    return this.projectInput().projectTitleTranslations;
  }

  set projectTitleTranslations(value: TranslationValue[]) {
    this.projectInput().projectTitleTranslations = value;
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

  get contactMailTranslations(){
    return this.projectInput().contactMailTranslations;
  }
  set contactMailTranslations(value: TranslationValue[]){
    this.projectInput().contactMailTranslations = value;
    this.onUpdated();
  }


  get contactPhone(): string {
    return this.projectInput().contactPhone;
  }

  set contactPhone(value: string) {
    this.projectInput().contactPhone = value;
      this.onUpdated();
  }
  get contactPhoneTranslations(){
    return this.projectInput().contactPhoneTranslations;
  }
  set contactPhoneTranslations(value: TranslationValue[]){
    this.projectInput().contactPhoneTranslations = value;
    this.onUpdated();
  }

  get longDescription(): string {
    return this.projectInput().longDescription;
  }

  set longDescription(value: string) {
    if(this.hasPastedToAngularEditorLongDescription){
      this.hasPastedToAngularEditorLongDescription = false;
      value = this.sanitizeHtml(value);
    }
    const projectInput = this.projectInput();
    projectInput.longDescription = value;
    if(!projectInput.longDescriptionTranslations){
      projectInput.longDescriptionTranslations = [];
    }
    const translation = projectInput.longDescriptionTranslations.find(x => x.language === this.descriptionMainLanguage);
    if(translation){
      translation.value = value;
    }else{
      projectInput.longDescriptionTranslations = [...projectInput.longDescriptionTranslations, new TranslationValue(this.descriptionMainLanguage, value)];
    }
      this.onUpdated();
  }

  get shortDescription(): string {
    return this.projectInput().shortDescription;
  }

  set shortDescription(value: string) {
    if(this.hasPastedToAngularEditorShortDescription){
      this.hasPastedToAngularEditorShortDescription = false;
      value = this.sanitizeHtml(value);
    }
      
    const projectInput = this.projectInput();
    projectInput.shortDescription = value;
    if(!projectInput.shortDescriptionTranslations){
      projectInput.shortDescriptionTranslations = [];
    }
    const translation = projectInput.shortDescriptionTranslations.find(x => x.language === this.descriptionMainLanguage);
    if(translation){
      translation.value = value;
    }else{
      projectInput.shortDescriptionTranslations = [...projectInput.shortDescriptionTranslations, new TranslationValue(this.descriptionMainLanguage, value)];
    }
      this.onUpdated();
  }

  get shortDescriptionOtherLanguage(): string {
    return stringEmptyPropagate(this.projectInput().shortDescriptionTranslations?.find(x => x.language === this.descriptionOtherLanguage)?.value, this.shortDescription);
  }
  get longDescriptionOtherLanguage(): string {
    return stringEmptyPropagate(this.projectInput().longDescriptionTranslations?.find(x => x.language === this.descriptionOtherLanguage)?.value, this.longDescription);
  }

  set shortDescriptionOtherLanguage(value: string) {
      
      if(this.hasPastedToAngularEditorShortDescriptionOtherLanguage){
        this.hasPastedToAngularEditorShortDescriptionOtherLanguage = false;
        value = this.sanitizeHtml(value);
      }
      
    const projectInput = this.projectInput();
    if(!projectInput.shortDescriptionTranslations){
      projectInput.shortDescriptionTranslations = [];
    }
    const translation = projectInput.shortDescriptionTranslations.find(x => x.language === this.descriptionOtherLanguage);
    if(translation){
      translation.value = value;
    }else{
      projectInput.shortDescriptionTranslations = [...projectInput.shortDescriptionTranslations, new TranslationValue(this.descriptionOtherLanguage, value)];
    }
    this.onUpdated();
  }

  set longDescriptionOtherLanguage(value: string) {
    if(this.hasPastedToAngularEditorLongDescriptionOtherLanguage){
      this.hasPastedToAngularEditorLongDescriptionOtherLanguage = false;
      value = this.sanitizeHtml(value);
    }
    const projectInput = this.projectInput();
    if(!projectInput.longDescriptionTranslations){
      projectInput.longDescriptionTranslations = [];
    }
    const translation = projectInput.longDescriptionTranslations.find(x => x.language === this.descriptionOtherLanguage);
    if(translation){
      translation.value = value;
    }else{
      projectInput.longDescriptionTranslations = [...projectInput.longDescriptionTranslations, new TranslationValue(this.descriptionOtherLanguage, value)];
    }
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

  get contactNameTranslations(){
    return this.projectInput().contactNameTranslations;
  }
  set contactNameTranslations(value: TranslationValue[]){
    this.projectInput().contactNameTranslations = value;
    this.onUpdated();
  }

  get organisationName(){
    return this.projectInput().organisationName;
  }
  set organisationName(value: string) {
    this.projectInput().organisationName = value;
    this.onUpdated();
  }

  get organisationNameTranslations(){
    return this.projectInput().organisationNameTranslations;
  }
  set organisationNameTranslations(value: TranslationValue[]){
    this.projectInput().organisationNameTranslations = value;
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
        message: this.translateService.instant("messages.helpProjectTitleMessage", {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive}),
        title: this.translateService.instant("messages.helpProjectTitleTitle")
      }),
      helpProjectPhase: new MessageDialogData({
        message: this.translateService.instant(`messages.helpProjectPhaseMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpProjectPhaseTitle`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName})
      }),
      helpProjectLocation: new MessageDialogData({
        message: this.translateService.instant(`messages.helpProjectLocationMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpProjectLocationTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
      }),
      helpProjectTime: new MessageDialogData({
        message: this.translateService.instant(`messages.helpProjectTimeMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpProjectTimeTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
      }),
      helpRequirements: new MessageDialogData({
        message: this.translateService.instant(`messages.helpRequirementsMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpRequirementsTitle`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName})
      }),
      helpContact: new MessageDialogData({
        message: this.translateService.instant(`messages.helpContactMessage`, {"yourDeclination": this.yourDeclination, "yoursDeclination": this.yoursDeclination, "typeName": this.typeName, "typeNameGenitive": this.typeNameGenitive}),
        title: this.translateService.instant(`messages.helpContactTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
      }),
      helpDescription: new MessageDialogData({
        message: this.translateService.instant(`messages.helpDescriptionMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpDescriptionTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
      }),
      helpImageUpload: new MessageDialogData({
        message: this.translateService.instant(`messages.helpImageUploadMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpImageUploadTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
      }),
      helpProjectVisibility: new MessageDialogData({
        message: this.translateService.instant(`messages.helpProjectVisibilityMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpProjectVisibilityTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
      }), 
      helpTags: new MessageDialogData({
          message: this.translateService.instant(`messages.helpTagsMessage`, {"yoursDeclinationDativeTo": this.yoursDeclinationDativeTo, "typeName": this.typeName}),
          title: this.translateService.instant(`messages.helpTagsTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
      }),
      helpVerificationPending: new MessageDialogData({
        message: this.translateService.instant(`messages.helpVerificationPendingMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpVerificationPendingTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
      }),
      helpVerificationApproved: new MessageDialogData({
        message: this.translateService.instant(`messages.helpVerificationApprovedMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName}),
        title: this.translateService.instant(`messages.helpVerificationApprovedTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
      }),
      helpVerificationRejected: (reason: string) => new MessageDialogData({
        message: this.translateService.instant(`messages.helpVerificationRejectedMessage`, {"yourDeclination": this.yourDeclination, "typeName": this.typeName, 
          "ReasonText": reason ? `<br>${reason}<br>`: ""}),
        isHtmlMessage: true,
        title: this.translateService.instant(`messages.helpVerificationRejectedTitle`, {"yoursDeclination": this.yoursDeclination, "typeName": this.typeNameGenitive})
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
    
    for(const file of validFiles){
      new UploadedImage(file).getBase64().then(x => {
        this.apiService.webApiEndpointsPostProjectImage({
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
            return
          }
          this.uploadedImages.push(UploadedImage.fromApi({
            imageId: y.imageIdentifier,
            type: "Additional" 
          }, this.apiBasePath, this.projectInput().entityId!));
        })
      })
    }
      
    
    this.fileUpload.nativeElement.value = "";
    this.onUpdated();
  }

  
  
  onUploadButtonClicked(){
    this.fileUpload.nativeElement.dispatchEvent(new MouseEvent("click", { bubbles: true }));
  }

  select(groupName: string){
    if(groupName === this.currentGroup) return;
    this.currentGroup = groupName;
    
    if(isPlatformBrowser(this.platformId)){
      const url = new URL(window.location.href);
      url.searchParams.set("group", groupName);
      window.history.replaceState({}, '', url.toString()); 
    }
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
        const tagOption = this.tagOptions.find(x => x.value === value);
          this.selectedTags.push(new SelectOption(value, value,null, tagOption?.valueTranslations, tagOption?.valueTranslations));
          this.onUpdated();
      }

      this.tagAutocompleteValue.set("");
      event.chipInput.clear();
  }

  tagSelected(event: MatAutocompleteSelectedEvent){
      event.option.deselect();
      if (!this.selectedTags.find(x => x.value === event.option.value)) {
        const tagOption = this.tagOptions.find(x => x.value === event.option.value);
          this.selectedTags.push(new SelectOption(event.option.value, event.option.viewValue, null, tagOption?.valueTranslations, tagOption?.valueTranslations));
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
    this.projectSaveContext()?.onChange(this.projectInput(), this.translateService.currentLang as Language);
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
      if(!isPlatformBrowser(this.platformId)){
        return "";
      }
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
  selectDescriptionLanguage(language: Language){
      this.isDescriptionOtherLanguageActive = this.descriptionMainLanguage !== language; 
  }
  get descriptionOtherLanguage(): Language{
      return this.descriptionMainLanguage === "it" ? "de" : "it";
  }
  get descriptionLanguageDeActive(){
      return !this.descriptionLanguageItActive;
  }
  get descriptionLanguageItActive(){
    return (this.descriptionMainLanguage === "it" && !this.isDescriptionOtherLanguageActive) ||
        (this.descriptionMainLanguage !== "it" && this.isDescriptionOtherLanguageActive);
  }
  
  get canUploadImages(){
      return !!this.projectInput().entityId;
  }
  
  get projectIsApproved(){
      const status = this.projectInput().approvalStatus;
      return status === "Approved" || status === "AutoApproved";
  }
  
  get projectIsRejected(){
      const status = this.projectInput().approvalStatus;
      return status === "Rejected";
  }

  showMessageDialogRejected() {
    this.showMessageDialog(this.messageDialogs.helpVerificationRejected(this.projectLastChangeReason));
  }

  get projectLastChangeReason(){
      const reason = this.projectInput().approvalStatusLastChangeReason;
      if(!reason){
        return "";
      }
      return this.translateService.instant("input-project.reason") + ": " + reason;
  }
  
  pasteAngularEditorShortDescription(){
    this.hasPastedToAngularEditorShortDescription = true;
  }
  pasteAngularEditorLongDescription(){
    this.hasPastedToAngularEditorLongDescription = true;
  }
  pasteAngularEditorShortDescriptionOtherLanguage(){
    this.hasPastedToAngularEditorShortDescriptionOtherLanguage = true;
  }
  pasteAngularEditorLongDescriptionOtherLanguage(){
    this.hasPastedToAngularEditorLongDescriptionOtherLanguage = true;
  }
  
  sanitizeHtml(html: string){
      if(!html){
        return "";
      }
      let hasImage = false;
      const doc = new DOMParser().parseFromString(html, 'text/html');
      const elements = doc.querySelector("body")!.querySelectorAll('*');
      const forbiddenTags = ["object", "script", "input", "iframe", "embed", "video", "audio", "source", "style", "link", "meta", "title", "html", "base", "head", "body", "svg"]
      elements.forEach(element => {
        const attributes = Array.from(element.attributes);
        if(element.tagName.toLowerCase() === "img"){
          hasImage = true;
          element.remove();
          return;
        }
        if(forbiddenTags.includes(element.tagName.toLowerCase())){
          element.remove();
          return;
        }
        attributes.forEach(attr => {
          if (element.tagName.toLowerCase() === 'a' && attr.name === 'href') {
            return;
          }

          if (attr.name === 'style') {
            const styles = attr.value.split(';').filter(x => !!x);
            const textAlign = styles.find(x => x.trim().toLowerCase().startsWith('text-align'));
            if (textAlign) {
              element.setAttribute('style', textAlign);
            } else {
              element.removeAttribute(attr.name);
            }
          } else {
            element.removeAttribute(attr.name);
          }
        });
      });
      if(hasImage) {
        this.dialog.open(MessageDialogComponent, {
          data: new MessageDialogData({
            message: this.translateService.instant("messages.htmlImgPasteMessage"),
            title: this.translateService.instant("messages.htmlImgPasteTitle"),
            buttonText: "Ok"
          })
        });
      }
      return doc.body.innerHTML;
  }
}
