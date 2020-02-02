/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AdEditBookComponent } from './ad-edit-book.component';

describe('AdEditBookComponent', () => {
  let component: AdEditBookComponent;
  let fixture: ComponentFixture<AdEditBookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdEditBookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdEditBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
