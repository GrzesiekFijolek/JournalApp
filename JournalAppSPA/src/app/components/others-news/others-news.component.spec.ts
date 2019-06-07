import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OthersNewsComponent } from './others-news.component';

describe('OthersNewsComponent', () => {
  let component: OthersNewsComponent;
  let fixture: ComponentFixture<OthersNewsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OthersNewsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OthersNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
