export interface UpdateToDoTaskCommand {
    identityUserId: string;
    noteId: number;
    toDoTaskId: number;
    name: string;
    dateLimit: string | null;
    priorityId: number;
    statusId: number;
}