import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequirementPersonsComponent } from './requirement-persons.component';

describe('RequirementPersonsComponent', () => {
  let component: RequirementPersonsComponent;
  let fixture: ComponentFixture<RequirementPersonsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RequirementPersonsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequirementPersonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
