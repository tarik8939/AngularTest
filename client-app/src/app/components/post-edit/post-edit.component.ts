import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Output, EventEmitter} from '@angular/core';
import {IPost} from "../../interfaces/IPost";

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html'
})
export class PostEditComponent implements OnInit {

  constructor(private fb: FormBuilder) {

  }

  @Input() post!: IPost;
  @Input() modal: any;
  @Output() editPostEvent = new EventEmitter<IPost>();
  postForm!: FormGroup;

  ngOnInit(): void {
    this.postForm = this.fb.group({
      title: [this.post.title, [Validators.required, Validators.minLength(3)]],
      text: [this.post.text, [Validators.required, Validators.minLength(3)]]
    })
  }

  update() {
    this.modal.close();
    this.editPost()
  }

  editPost() {
    this.editPostEvent.emit(this.postForm.value);
  }


}
