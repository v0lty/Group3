import DatePicker from 'sassy-datepicker';

export default function Sidebar_Latest() {
    const onChange = (date) => {
        console.log(date.toString());
    };

    return (
        <DatePicker onChange={onChange} />
    );
}