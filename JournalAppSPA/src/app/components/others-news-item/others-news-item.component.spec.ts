import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OthersNewsItemComponent } from './others-news-item.component';

describe('OthersNewsItemComponent', () => {
  let component: OthersNewsItemComponent;
  let fixture: ComponentFixture<OthersNewsItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OthersNewsItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OthersNewsItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
