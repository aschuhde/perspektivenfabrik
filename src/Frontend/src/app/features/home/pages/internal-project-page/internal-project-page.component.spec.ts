import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternalProjectPageComponent } from './internal-project-page.component';

describe('InternalProjectPageComponent', () => {
  let component: InternalProjectPageComponent;
  let fixture: ComponentFixture<InternalProjectPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InternalProjectPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InternalProjectPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
