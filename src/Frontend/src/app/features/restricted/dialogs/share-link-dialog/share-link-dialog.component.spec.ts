import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShareLinkDialogComponent } from './share-link-dialog.component';

describe('ShareLinkDialogComponent', () => {
  let component: ShareLinkDialogComponent;
  let fixture: ComponentFixture<ShareLinkDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShareLinkDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShareLinkDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
