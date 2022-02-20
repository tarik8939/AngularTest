import {Injectable} from '@angular/core';
import {IPost} from "../interfaces/IPost";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable, tap} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class PostService {
  public posts: IPost[] = [];

  constructor(private http: HttpClient) {
  }

  fetchPosts(): Observable<IPost[]> {
    return this.http.get<IPost[]>("https://localhost:5001/api/Post")
      .pipe(tap((posts) => this.posts = posts))
  }

  getPost(id:number): IPost {
    return this.posts.filter(x => x.postId == id)[0];
  }

  createPost(post: IPost): any{
    this.http.post("https://localhost:5001/api/Post",post)
      .subscribe( data => {
        console.log(data)
        // @ts-ignore
        this.posts = [...this.posts, data]
      })
  }

  updatePost(id: number,post: IPost): Observable<void>{
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<IPost>(`https://localhost:5001/api/Post/${id}`, post, { headers })
      .pipe(
        tap((data:any) => {
          this.posts = [... this.posts.map(x=>x.postId === data.postId ? {...data} : x)]
        })
      );
  }

  deletePost(id: number) {
    return this.http.delete<any>(`https://localhost:5001/api/Post/${id}`)
      .pipe(
        tap((data:any) => {
          this.posts = [... this.posts.filter(x=>x.postId !== id)]
        })
      );
  }


}
