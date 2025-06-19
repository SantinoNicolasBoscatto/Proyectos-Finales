import { Category } from "../Category/Category";
import { ToDoTask } from "../ToDoTask/ToDoTask";


export interface Note {
    id: number;
    name: string;
    identityUserId: string;
    categoryId: number;
    category: Category;
    toDoTasks: ToDoTask[] | null;
}