import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequirementMaterialsDialogComponent } from './requirement-materials-dialog.component';

describe('RequirementMaterialsDialogComponent', () => {
  let component: RequirementMaterialsDialogComponent;
  let fixture: ComponentFixture<RequirementMaterialsDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RequirementMaterialsDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequirementMaterialsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
