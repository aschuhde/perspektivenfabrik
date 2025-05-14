import { Component, inject } from '@angular/core';
import { MapComponent } from '../../components/map/map.component';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import {TranslateModule } from '@ngx-translate/core';
import {TranslationValue} from "../../models/translation-value";
import {MatInputTranslationsComponent} from "../../components/mat-input-translations/mat-input-translations.component";
import {LanguageService} from "../../../core/services/language-service.service";
import {Language} from "../../../core/types/general-types";
import {MatInput, MatFormField, MatLabel} from '@angular/material/input';

@Component({
  selector: 'app-map-dialog',
  imports: [MatInput, MatFormField, MatLabel, FormsModule, MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MapComponent, TranslateModule, MatInputTranslationsComponent],
  templateUrl: './map-dialog.component.html',
  styleUrl: './map-dialog.component.scss'
})
export class MapDialogComponent {
  data = inject(MAT_DIALOG_DATA);
  retrievedPoint: string = ""
  retrievedPointTranslations: TranslationValue[] = []
  retrievedPointDisplayName: string = ""
  retrievedPointDisplayNameTranslations: TranslationValue[] = []
  lookupMode = this.data?.lookupMode ?? "address";
  type: "lookup" | "display" = this.data?.type ?? "lookup";
  startPoint: string = this.data?.startPoint ?? "";
  languageService = inject(LanguageService)
  retrievedPointSelectedLanguage: Language = this.languageService.currentLanguageCode;
  
  ngOnInit(){
    if(this.startPoint){
      this.mapRetrievedPoint(this.startPoint, "", [], []);
    }
    this.retrievedPointSelectedLanguage = this.languageService.currentLanguageCode;
  }
  
  get retrievedPointValid(){
    return !!this.retrievedPoint?.replaceAll(".", "")?.trim();
  }
  mapRetrievedPoint(name: string, displayName: string, nameTranslations: TranslationValue[], displayNameTranslations: TranslationValue[]){
    this.retrievedPointSelectedLanguage = this.languageService.currentLanguageCode;
    this.retrievedPoint = name;
    this.retrievedPointTranslations = nameTranslations;
    this.retrievedPointDisplayName = displayName ?? "";
    this.retrievedPointDisplayNameTranslations = displayNameTranslations;
  }
  apply(){
    if(!this.retrievedPoint){
      return;
    }
    if(this.data?.onApply){
      this.data.onApply(this.retrievedPoint, this.retrievedPointDisplayName, this.retrievedPointTranslations, this.retrievedPointDisplayNameTranslations, this.retrievedPointSelectedLanguage);
    }
  }
}
