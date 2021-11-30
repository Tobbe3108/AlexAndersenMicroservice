import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    vus: 10,
    duration: '30s'
};

export default () => {
    http.get('https://localhost:7017/Delivery/TestPackageId');
}