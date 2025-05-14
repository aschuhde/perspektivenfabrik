import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatInputTranslationsComponent } from './mat-input-translations.component';

describe('MatInputTranslationsComponent', () => {
  let component: MatInputTranslationsComponent;
  let fixture: ComponentFixture<MatInputTranslationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MatInputTranslationsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MatInputTranslationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
