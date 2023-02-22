import i18n from 'i18next';
import LanguageDetector from 'i18next-browser-languagedetector';
import { initReactI18next } from 'react-i18next';
import ns1 from '../../../locales/pt-BR.json';
import ns2 from '../../../locales/en.json';

const resources = {
    en: ns2,
    pt: ns1,
};

function ConfigureMultiLangage() {
    i18n        
        .use(LanguageDetector)
        .use(initReactI18next)
        .init({                     
            debug: true,
            returnNull: false,
            fallbackLng: ['en', 'pt-BR'], // idioma de fallback                       
            interpolation: {
                escapeValue: false, // not needed for react as it escapes by default
            },
            resources            
        });    

    return i18n;    
}

export default ConfigureMultiLangage;
