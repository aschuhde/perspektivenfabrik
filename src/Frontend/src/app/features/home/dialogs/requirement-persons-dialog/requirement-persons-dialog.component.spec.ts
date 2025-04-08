import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequirementPersonsDialogComponent } from './requirement-persons-dialog.component';

describe('RequirementPersonsDialogComponent', () => {
  let component: RequirementPersonsDialogComponent;
  let fixture: ComponentFixture<RequirementPersonsDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RequirementPersonsDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequirementPersonsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
