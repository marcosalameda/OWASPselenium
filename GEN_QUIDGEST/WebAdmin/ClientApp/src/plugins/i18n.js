
import QGlobal from '@/global';
import defaultResources from '@/translations/resources.en-US.json';
import EventBus from '@/utils/eventBus';
import { createI18n } from 'vue-i18n'

var messages = {
  'en-US': defaultResources
};

export function setupI18n(options = {
    globalInjection: true,
    legacy: false,
    locale: QGlobal.defaultLang, // set locale
    fallbackLocale: QGlobal.defaultLang, // set fallback locale
    messages, // set locale messages
}) {
    const i18n = createI18n(options);
    setI18nLanguage(i18n, options.locale);
    return i18n;
}

export function setI18nLanguage(i18n, locale) {
    if (i18n.mode === 'legacy') {
        i18n.global.locale = locale;
    } else {
        i18n.global.locale.value = locale;
    }

    document.querySelector('html').setAttribute('lang', locale);

    EventBus.emit('SET_CULTURE', locale);

    return locale;
}

export function loadLocaleMessages(i18n, locale) {
    // If the same language
    if (i18n.global.locale === locale) {
        return Promise.resolve(setI18nLanguage(i18n, locale));
    }

    // If the language was already loaded
    if (i18n.global.availableLocales.includes(locale)) {
        return Promise.resolve(setI18nLanguage(i18n, locale));
    }

    // If the language hasn't been loaded yet
    return import(/* webpackChunkName: "locale-[request]" */ `@/translations/resources.${locale}.json`).then(
        messages => {
            i18n.global.setLocaleMessage(locale, messages.default);
            return setI18nLanguage(i18n, locale);
        }
    );
}