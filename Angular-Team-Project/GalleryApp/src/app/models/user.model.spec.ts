import { User } from './user.model';

describe('User', () => {
    let model: User;

    beforeEach(() => {
        model = new User();
    });

    it('should be create successfully', () => {
        // Arrange, Act & Assert
        expect(model).toBeTruthy();
    });
    it('should property $key be assign correctly', () => {
        // Arrange
        const testKey = 'testKey';
        // Act
        model.$key = testKey;
        // Assert
        expect(model.$key).toEqual(testKey);
    });
    it('should property uid be assign correctly', () => {
        // Arrange
        const testUid = 'testUID';
        // Act
        model.uid = testUid;
        // Assert
        expect(model.uid).toEqual(testUid);
    });
    it('should property email be assign correctly', () => {
        // Arrange
        const testEmail = 'test@abv.bg';
        // Act
        model.email = testEmail;
        // Assert
        expect(model.email).toEqual(testEmail);
    });
    it('should property password be assign correctly', () => {
        // Arrange
        const testPass = 'testpass';
        // Act
        model.password = testPass;
        // Assert
        expect(model.password).toEqual(testPass);
    });
});
