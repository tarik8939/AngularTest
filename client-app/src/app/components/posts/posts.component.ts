import {Component, OnInit, TemplateRef} from '@angular/core';
import {PostService} from "../../services/post.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {IPost} from "../../interfaces/IPost";

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html'
})
export class PostsComponent implements OnInit {

  constructor(public postsService: PostService, private modalService: NgbModal) {
  }

  closeResult = '';
  selectedPost!: IPost;

  ngOnInit(): void {
    this.postsService.fetchPosts()
      .subscribe(() => {
        console.log(this.postsService.posts)
      })

  }

  editPost(newItem: IPost) {
    this.postsService.updatePost(this.selectedPost.postId, newItem)
      .subscribe((data: any) => console.log(data))
  }

  addNew(newItem: IPost){
    this.postsService.createPost(newItem)
  }

  openEdit(content: TemplateRef<any>, index: number) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
    });
    this.selectedPost = this.postsService.getPost(index);
  }

  openNew(content: TemplateRef<any>) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
    });
  }

  delete(id: number) {
    this.postsService.deletePost(id).subscribe({
      next: data => {
        console.log(data);
      },
      error: error => {
        console.error(error);
      }
    })
  }




}
