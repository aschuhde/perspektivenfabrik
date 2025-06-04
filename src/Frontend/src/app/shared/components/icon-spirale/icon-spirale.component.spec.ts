import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IconSpiraleComponent } from './icon-spirale.component';

describe('IconSpiraleComponent', () => {
  let component: IconSpiraleComponent;
  let fixture: ComponentFixture<IconSpiraleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IconSpiraleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IconSpiraleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
