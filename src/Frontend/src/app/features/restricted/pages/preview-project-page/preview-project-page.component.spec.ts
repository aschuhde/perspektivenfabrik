import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreviewProjectPageComponent } from './preview-project-page.component';

describe('PreviewProjectPageComponent', () => {
  let component: PreviewProjectPageComponent;
  let fixture: ComponentFixture<PreviewProjectPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PreviewProjectPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PreviewProjectPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
