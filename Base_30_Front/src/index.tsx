import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import { BrowserRouter } from 'react-router-dom';
import './index.css';
import { RecoilRoot } from 'recoil';
import ConfigureMultiLangage from './Core/Presentation/MultiLanguage/i18n';
import { I18nextProvider } from 'react-i18next';

ReactDOM.render(
    <React.StrictMode>
        <I18nextProvider i18n={ConfigureMultiLangage()}>
            <BrowserRouter>
                <RecoilRoot>
                    <App />
                </RecoilRoot>
            </BrowserRouter>
        </I18nextProvider>
    </React.StrictMode>,
    document.getElementById('root')
);