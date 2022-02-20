import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {IPost} from "../../interfaces/IPost";

@Component({
  selector: 'app-post-new',
  templateUrl: './post-new.component.html'
})
export class PostNewComponent implements OnInit {

  constructor(private fb: FormBuilder,) { }
  @Output() newPostEvent = new EventEmitter<IPost>();
  @Input() modal: any;
  postForm!: FormGroup;
  post!: IPost;

  ngOnInit(): void {
    this.postForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(3)]],
      text: ['', [Validators.required, Validators.minLength(3)]]
    })
  }

  update() {
    this.modal.close();
    this.adddNewPost()
  }

  adddNewPost() {
    this.newPostEvent.emit(this.postForm.value);
  }

}
