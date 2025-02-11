import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputContactSpecificationComponent } from './input-contact-specification.component';

describe('InputContactSpecificationComponent', () => {
  let component: InputContactSpecificationComponent;
  let fixture: ComponentFixture<InputContactSpecificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputContactSpecificationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputContactSpecificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
