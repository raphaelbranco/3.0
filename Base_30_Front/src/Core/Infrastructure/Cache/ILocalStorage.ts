export interface ILocalStorage {
    getStorage: (key: string) => object | null
    setStorage: (key: string, value: object | null) => void
  }
  