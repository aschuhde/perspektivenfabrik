import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstaIconComponent } from './insta-icon.component';

describe('InstaIconComponent', () => {
  let component: InstaIconComponent;
  let fixture: ComponentFixture<InstaIconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstaIconComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InstaIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
