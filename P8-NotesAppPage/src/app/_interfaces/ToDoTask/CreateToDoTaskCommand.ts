export interface CreateToDoTaskCommand {
    identityUserId: string;
    noteId: number;
    name: string;
    dateLimit: string | null;
    priorityId: number;
    statusId: number;
}