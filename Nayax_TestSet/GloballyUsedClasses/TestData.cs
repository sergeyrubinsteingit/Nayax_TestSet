using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Nayax_TestSet.GloballyUsedClasses
{
    class TestData
    {

        public static string testValue;


        [Flags]
        public enum KeyWords
            {
                HOST_QA, URL_QA, URL_PROD, URL_MACHINES, URL_SALES_SUMMARY, CORTEX_API_URL, ACTOR_QA, ACTOR_PROD, USER_MAIL, USER_MAIL_INPUT, USER_PASS_INPUT, PASS_QA, PASS_PROD, SETUP_MFA_BUTTON,
                SMS_LOGIN_FIELD, MOMA_LOGIN_FIELD, SIGNIN_BUTTON, DONT_TRUST_BUTTON, COOKIE_BAR, COOKIE_CONFIRM_BUTTON, AGREEMENT_WIN, AGREEMENT_LIST,
                AGREEMENT_BOX, AGREEMENT_BUTTON, NOTIF_SUCCESS, NOTIF_ERROR, FILTER_CONTAINER, MENU_THEME_ICON, ACTOR_FIELD, ACTOR_NAME_ENTRY, ACTOR_SEARCH_BUTTON, UNASSIGNED_AREA, TEST_MASHINE,
                TAB_DASHBOARD, TAB_GENERAL, CHART_12VS12, TOOLTIP_12MONTH, ACTOR_FIELD_REPORTS, VIEW_REPORT_BUTTON, TIME_PERIOD_FIELD, TIME_LIST, DATE_RANGE_ENTRY, DATE_RANGE_START_FIELD,
                DATE_RANGE_END_FIELD, DATE_RANGE_START_TIME, DATE_RANGE_END_TIME, SALES_BY_MACHINE_TAB, TEST_MACHINE_NAME, TEST_MACHINE_DEFAULT_NAME, TEST_RESULT_DISPLAY, BTN_DASHBOARD_ACTIONS, ADD_DASHBOARD_WIDGET,
                ADD_WIDGET_WIN, WIDGET_THUMBNAIL, CURRENCY_THUMBNAIL,
        }


        public static readonly Dictionary<KeyWords, string> TestKeyValues = new Dictionary<KeyWords, string>()
            {
                {KeyWords.HOST_QA, "qa.nayax.com"},
                {KeyWords.URL_QA, "https://qa.nayax.com/core/LoginPage.aspx"},
                {KeyWords.URL_PROD, "https://my.nayax.com/core/LoginPage.aspx"},
                {KeyWords.URL_MACHINES, "https://qa.nayax.com/core/public/facade.aspx?model=operations/machine"},
                {KeyWords.URL_SALES_SUMMARY, "https://qa.nayax.com/core/public/facade.aspx?model=reports/SalesSummary"},
                {KeyWords.CORTEX_API_URL, "https://qa-cortex.nayax.com/users/v1/signin"},
                {KeyWords.ACTOR_QA, "sergey_EatDrinkSleepDie57"},
                {KeyWords.ACTOR_PROD, "rubiserg_BuDrR1eluoT"},
                {KeyWords.USER_MAIL, "sergeyr"},
                {KeyWords.PASS_QA, "Rubi69nayaxqa-1*"},
                {KeyWords.PASS_PROD, "rubi69production-3*"},
                {KeyWords.USER_MAIL_INPUT, "input#txtUser"},
                {KeyWords.USER_PASS_INPUT, "input#txtPassword"},
                {KeyWords.SETUP_MFA_BUTTON, "input#setupMfa"},
                {KeyWords.SMS_LOGIN_FIELD, "input#second_factor_option_sms_input"},
                {KeyWords.MOMA_LOGIN_FIELD, "input#second_factor_option_totp_input"},
                {KeyWords.SIGNIN_BUTTON, "input#signin"},
                {KeyWords.DONT_TRUST_BUTTON, "input#trustDeviceNever"},
                {KeyWords.COOKIE_BAR, "div#onetrust-banner-sdk"},
                {KeyWords.COOKIE_CONFIRM_BUTTON, "button#onetrust-accept-btn-handler"},
                {KeyWords.AGREEMENT_WIN, "div#agreement_win"},
                {KeyWords.AGREEMENT_LIST, "//*[@id=\'agreement_list\']/div[2]"},
                {KeyWords.AGREEMENT_BOX, "input#agreement_1"},
                {KeyWords.AGREEMENT_BUTTON, "a#continue_btn"},
                {KeyWords.NOTIF_SUCCESS, "div.notification.success"},
                {KeyWords.NOTIF_ERROR, "div.notification.error"},
                {KeyWords.FILTER_CONTAINER, "div#filter_container"},
                {KeyWords.MENU_THEME_ICON, "div#menu_theme_icon"},
                {KeyWords.ACTOR_FIELD, "input#actor_id_filter_input"},
                {KeyWords.ACTOR_NAME_ENTRY, "p.pickerText"},
                {KeyWords.ACTOR_SEARCH_BUTTON, "button#search_machine_btn"},
                {KeyWords.UNASSIGNED_AREA, "//a[contains(text(), \'Unassigned Area\')]"},
                {KeyWords.TEST_MASHINE, "//a[contains(text(), \'aAlpha-TestMachine\')]"},
                {KeyWords.TAB_DASHBOARD, "li#tab_dashboard"},
                {KeyWords.TAB_GENERAL, "li#tab_general"},
                {KeyWords.CHART_12VS12, "div#widget_36012196625"},
                {KeyWords.TOOLTIP_12MONTH, "//div[contains(text(),'05/2024')]"},
                {KeyWords.ACTOR_FIELD_REPORTS, "input#actor_id_input"},
                {KeyWords.VIEW_REPORT_BUTTON, "button#showReport"},
                {KeyWords.TIME_PERIOD_FIELD, "td#time_period"},
                {KeyWords.TIME_LIST, "ul#time_period_select_listbox"},
                {KeyWords.DATE_RANGE_ENTRY, "//li[contains(text(),'Date Range')]"},
                {KeyWords.DATE_RANGE_START_FIELD, "input#start_date_input"},
                {KeyWords.DATE_RANGE_END_FIELD, "input#end_date_input"},
                {KeyWords.DATE_RANGE_START_TIME, "5/01/2024 00:00 AM"},
                {KeyWords.DATE_RANGE_END_TIME, "5/31/2024 11:00 PM"},
                {KeyWords.SALES_BY_MACHINE_TAB, "li#sales_by_machine_tab"},
                {KeyWords.TEST_MACHINE_NAME, "//span[contains(text(),'TestMachine')]"},
                {KeyWords.TEST_MACHINE_DEFAULT_NAME, "//span[contains(text(),'[object HTMLTableCellElement]')]"},
                {KeyWords.TEST_RESULT_DISPLAY, "div#TestResultDisplay"},
                {KeyWords.BTN_DASHBOARD_ACTIONS, "div#btn_dashboard_actions"},
                {KeyWords.ADD_DASHBOARD_WIDGET, "li#add_dashboard_widget"},
                {KeyWords.ADD_WIDGET_WIN, "div#add_widget_win"},
                {KeyWords.WIDGET_THUMBNAIL, "div.widget_thumbnail"},
                {KeyWords.CURRENCY_THUMBNAIL, "div#widget_36012196625-currency"},
            };        
    }
}