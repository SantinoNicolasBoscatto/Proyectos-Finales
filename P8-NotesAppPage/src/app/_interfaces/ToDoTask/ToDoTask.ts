import { Note } from "../Note/Note";
import { Priority } from "../Priority/Priority";
import { Status } from "../Status/Status";

export interface ToDoTask {
    id: number;
    noteId: number;
    name: string | null;
    dateLimit: string | null;
    priorityId: number;
    statusId: number;
    priority: Priority | null;
    status: Status | null;
    note: Note | null;
}