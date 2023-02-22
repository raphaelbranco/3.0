export interface FieldValidation {
    fieldName: string
    validate: (input: Record<string, unknown>) => Error | null
}