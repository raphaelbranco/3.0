import styles from './Spinner.module.scss';

type Props = {
    isLoading: boolean
}

const Spinner: React.FC<Props> = ({isLoading}: Props) => {
    return (                
        <div>
            {isLoading && <div className={styles.ldsdualring}><div></div><div></div><div></div></div>}
        </div> 
        
    );
};
  
export default Spinner;