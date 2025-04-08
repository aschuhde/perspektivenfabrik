import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequirementMaterialsComponent } from './requirement-materials.component';

describe('RequirementMaterialsComponent', () => {
  let component: RequirementMaterialsComponent;
  let fixture: ComponentFixture<RequirementMaterialsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RequirementMaterialsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequirementMaterialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
